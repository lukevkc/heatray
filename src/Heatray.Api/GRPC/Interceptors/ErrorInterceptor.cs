using System.Diagnostics;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Heatray.Infrastructure.Extensions.Exceptions;

namespace Heatray.Api.gRPC.Interceptors;

public class ErrorInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (Exception e)
        {
            throw e.Handle<TResponse>(context, Trace.CorrelationManager.ActivityId.ToString());
        }
    }
}