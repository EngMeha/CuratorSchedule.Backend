namespace GroupService.Application.Interfaces;

public interface ICurrentUserService
{
    public Guid UserId { get; }
}