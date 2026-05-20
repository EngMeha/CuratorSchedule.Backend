namespace GroupService.Application.Exceptions;

public class UniqueConstraintViolationException: Exception
{
    public UniqueConstraintViolationException(string inner, Exception ex) : base(inner, ex)
    {
        
    }
}