using System.Diagnostics;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Heatray.Api.gRPC.Interceptors;

public class CorrelationInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        if (Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
        {
            Trace.CorrelationManager.ActivityId = Guid.NewGuid();
        }
        context.RequestHeaders.Add("correlation-id", Trace.CorrelationManager.ActivityId.ToString());
        return await base.UnaryServerHandler(request, context, continuation);
    }
}