using GroupService.Application.Interfaces;

namespace GroupService.Infrastructure.Data;

public class EfUnitOfWork: IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //TODO прописать реализацию
        throw new NotImplementedException();
    }
}