namespace Domain.Exceptions;

public class NotFoundUser: Exception
{
    public NotFoundUser()
    {
    }
    public NotFoundUser(string message) : base(message)
    {}
    
    public NotFoundUser(string message, Exception inner) : base(message, inner)
    {}
}