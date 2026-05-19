namespace GroupService.Application.Interfaces.Ports;

public interface IAddPort<in TEntity>: IPortMarker where TEntity: class
{
    public Task<Guid> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
}