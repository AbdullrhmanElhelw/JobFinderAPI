namespace Domain.Shared;

public class Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }

    protected Result(bool isSuccess, Error? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Ok() => new(true, null);

    public static Result Fail(Error error) => new(false, error);

    public static Result<T> Ok<T>(T value) => new(true, value, null);

    public static Result<T> Fail<T>(Error error) => new(false, default!, error);
}