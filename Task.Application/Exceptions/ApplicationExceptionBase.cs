namespace Task.Application.Exceptions;

public class ApplicationExceptionBase : Exception
{
    public IReadOnlyCollection<string> Errors { get; }

    protected ApplicationExceptionBase(IEnumerable<string> errors)
    {
        Errors = errors.ToList();
    }
}
