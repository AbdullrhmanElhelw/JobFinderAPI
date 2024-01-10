namespace Domain.Shared;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
       nameof(ValidationError));

    Error[] Errors { get; }
}
