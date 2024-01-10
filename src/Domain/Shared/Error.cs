namespace Domain.Shared;

public class Error(string message)
{
    public string Message { get; } = message;

    public static readonly Error None = new(string.Empty);

    public static readonly Error NotFound = new("Not found.");

    public static readonly Error InternalServerError = new("Internal server error.");

    public static readonly Error Unauthorized = new("Unauthorized.");

    public static readonly Error Forbidden = new("Forbidden.");

    public static readonly Error Invalid = new("Invalid.");

    public static implicit operator string(Error error) => error.Message;

    public static implicit operator Error(string message) => new(message);
}