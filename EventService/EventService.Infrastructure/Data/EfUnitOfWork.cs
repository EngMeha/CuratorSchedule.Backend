using EventService.Application.Interfaces;

namespace EventService.Infrastructure.Data;

public class EfUnitOfWork: IUnitOfWork
{
    private readonly EventDbContext _eventDbContext;

    public EfUnitOfWork(EventDbContext eventDbContext)
    {
        _eventDbContext = eventDbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _eventDbContext.SaveChangesAsync(cancellationToken);
    }
}