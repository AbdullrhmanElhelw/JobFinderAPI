namespace Domain.Shared;

public class ValidationResult<T> : Result<T>, IValidationResult
{
    private ValidationResult(Error[] errors) : base(false, default!, IValidationResult.ValidationError)
    {
        Errors = errors;
    }

    public Error[] Errors { get; }
}