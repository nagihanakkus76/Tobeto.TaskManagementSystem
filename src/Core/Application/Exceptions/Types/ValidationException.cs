namespace Core.Application.Exceptions.Types;

public class ValidationException : Exception
{
    public IEnumerable<string> Errors { get; set; }

    public ValidationException(IEnumerable<string> errors)
    {
        Errors = errors;
    }
}
