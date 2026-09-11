namespace Shop.Application.Common;

public class Result
{
    public bool IsSuccess { get; }
    public string? Error { get; }

    private Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
    => new(true, null);

    public static Result Failure(IEnumerable<string> errors)
        => new(false, string.Join(", ", errors));

}

