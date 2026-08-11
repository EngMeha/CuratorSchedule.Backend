namespace EventService.Domain.Expetions;

public class DomainException: Exception
{
    public  DomainException(string message)
        : base(message)
    {
    }
}