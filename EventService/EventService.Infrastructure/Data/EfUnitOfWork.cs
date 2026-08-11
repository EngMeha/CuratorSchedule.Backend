using EventService.Application.Exceptions;
using EventService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EventService.Infrastructure.Data;

public class EfUnitOfWork: IUnitOfWork
{
    private readonly EventDbContext _context;

    public EfUnitOfWork(EventDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (DbUpdateException ex) when(ex.InnerException is PostgresException pgEx &&
                                          pgEx.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            throw new UniqueConstraintViolationException("Unique constraint violated.", ex);
        }
    }
}