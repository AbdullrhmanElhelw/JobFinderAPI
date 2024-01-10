namespace Domain.Shared;

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(bool isSuccess, TValue value, Error? error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException("There is no value for failure.");

    public static implicit operator TValue(Result<TValue> result) => result.Value;

    public static implicit operator Result<TValue>(TValue value) => Create(value);

    public static Result<TValue> Create(TValue value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        return new Result<TValue>(true, value, Error.None);
    }
}