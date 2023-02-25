namespace Infrastructure.Services;

public class Response
{
    public bool Success { get; internal init; } = true;
    public string? Message { get; internal init; }

    public static Response Pass() => new Response { Success = true };
    public static Response<T> Pass<T>(T data) => new(data);
    public static FailureResponse Fail(string reason) => new(reason);
    public static FailureResponse Fail(Response other) => new(other.Message);

    public static implicit operator Response(FailureResponse failure)
    {
        return new Response
        {
            Success = false,
            Message = failure.Message,
        };
    }
}

public sealed class Response<T> : Response
{
    public T Data { get; internal init; }

    public Response(T data)
    {
        Data = data;
    }

    public static implicit operator Response<T>(FailureResponse failure)
    {
        return new Response<T>(default!)
        {
            Success = false,
            Message = failure.Message,
        };
    }
}

public sealed class FailureResponse 
{
    internal FailureResponse(string? message)
    {
        Message = message;
    }

    public string? Message { get; }
}
