using EventService.Application.Interfaces;

namespace EventService.Infrastructure.Data;

public class EfUnitOfWork: IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //TODO прописать реализацию
        throw new NotImplementedException();
    }
}