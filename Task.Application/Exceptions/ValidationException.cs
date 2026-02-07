namespace Task.Application.Exceptions;

public class ValidationException : ApplicationExceptionBase
{
    public ValidationException(IEnumerable<string> errors) : base(errors)
    {
    }
}
