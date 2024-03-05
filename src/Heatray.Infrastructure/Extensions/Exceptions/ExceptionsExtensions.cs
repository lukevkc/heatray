using Grpc.Core;

namespace Heatray.Infrastructure.Extensions.Exceptions;

public static class ExceptionsExtensions
{
    public static RpcException Handle<T>(this Exception exception, ServerCallContext context, string correlationId)
    {
        return exception switch
        {
            TimeoutException timeoutException => HandleTimeoutException<T>(timeoutException, context, correlationId),
            RpcException rpcException => HandleRpcException<T>(rpcException, context, correlationId),
            _ => HandleDefault<T>(exception, context, correlationId)
        };
    }

    private static RpcException HandleTimeoutException<T>(TimeoutException exception, ServerCallContext context,
        string correlationId)
    {
        var status = new Status(StatusCode.Internal, "An external resource did not answer within the time limit.");
        return new RpcException(status, CreateTrailers(correlationId));
    }

    private static RpcException HandleRpcException<T>(RpcException exception, ServerCallContext context,
        string correlationId)
    {
        return new RpcException(new Status(exception.StatusCode, exception.Status.Detail), CreateTrailers(correlationId));
    }

    private static RpcException HandleDefault<T>(Exception exception, ServerCallContext context, string correlationId)
    {
        return new RpcException(new Status(StatusCode.Internal, exception.Message), CreateTrailers(correlationId));
    }

    private static Metadata CreateTrailers(string correlationId)
    {
        var trailers = new Metadata { { "correlation-id", correlationId } };
        return trailers;
    }
}