namespace Shop.Application.Common;

public class Result
{
    public bool IsSuccess { get; }
    public string? Error { get; }

    protected Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
    => new(true, null);

    public static Result Failure(IEnumerable<string> errors)
        => new(false, string.Join(", ", errors));

}

public class Result<T> : Result {
    public T? Data { get; }

    private Result(bool isSuccess, T? data, string? error): base(isSuccess, error)
    {
        Data = data;
    }

    public static Result<T> Success(T data)
        => new(true, data, null);

    public static Result<T> Failure(IEnumerable<string> errors)
        => new(false, default, string.Join(", ", errors));
}
