using System.Diagnostics;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Heatray.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace Heatray.Api.gRPC.Interceptors
{
    public class AuthInterceptor : Interceptor
    {
        private readonly IOptions<AuthConfiguration> _authConfiguration;

        public AuthInterceptor(IOptions<AuthConfiguration> authConfiguration)
        {
            _authConfiguration = authConfiguration;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var metadata = context.RequestHeaders;
            if (metadata.All(w => w.Key != "secret-key") || metadata.GetValue("secret-key") != _authConfiguration.Value.AccessSecret)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid secret key."),
                    new Metadata { { "correlation-id", Trace.CorrelationManager.ActivityId.ToString() } });
            }

            return await base.UnaryServerHandler(request, context, continuation);
        }
    }
}