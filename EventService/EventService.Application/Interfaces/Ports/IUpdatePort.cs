namespace EventService.Application.Interfaces.Ports;

public interface IUpdatePort<in TEntity>: IPortMarker where TEntity: class
{
    public void Update(TEntity entity);
}