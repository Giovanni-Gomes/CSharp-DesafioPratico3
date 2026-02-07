namespace Task.Application.Exceptions;

public class NotFoundException : ApplicationExceptionBase
{
    public NotFoundException(string message) : base(new[] { message }) { }
}
