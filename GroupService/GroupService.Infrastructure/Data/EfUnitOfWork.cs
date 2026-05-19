using GroupService.Application.Exceptions;
using GroupService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GroupService.Infrastructure.Data;

public class EfUnitOfWork: IUnitOfWork
{
    private readonly GroupContext _context;

    public EfUnitOfWork(GroupContext context)
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