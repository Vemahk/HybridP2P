using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public abstract class ServiceBase<TService>
    where TService : ServiceBase<TService>
{
    protected readonly ILogger<TService> Logger;

    protected ServiceBase(ILogger<TService> logger)
    {
        Logger = logger;
    }

    protected static Response Pass() => Response.Pass();
    protected static Response<T> Pass<T>(T data) => Response.Pass(data);
    protected static FailureResponse Fail(string reason) => Response.Fail(reason);
    protected static FailureResponse Fail(Response other) => Response.Fail(other);

    protected FailureResponse UnexpectedError(Exception e, string? message = null)
    {
        message ??= e.Message;
        Logger.LogError("{message} {exception}", message, e);
        return Fail(message ?? e.Message);
    }
}
