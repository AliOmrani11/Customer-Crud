using FluentValidation.Results;

namespace Application.Exceptions;

internal class ValidationException : ApplicationException
{
    public ValidationException()
        : base("One or more validation failures have occured.")
    {
        Errors = new Dictionary<string, string[]>();
    }
    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(s => s.PropertyName, s => s.ErrorMessage)
            .ToDictionary(f => f.Key, f => f.ToArray());
    }
    public Dictionary<string, string[]> Errors { get; set; }
}
