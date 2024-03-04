using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Heatray.Api.GRPC.Interceptors
{
    public class AuthInterceptor : Interceptor
    {
        private const string SecretKey = "2SdqXGyYqUTs0JI5PlT2gUTnJTjIcnXd";
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var metadata = context.RequestHeaders;
            if (metadata.All(w => w.Key != "secret-key") || metadata.GetValue("secret-key") != SecretKey)
            {
                throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid secret key."));
            }

            return await base.UnaryServerHandler(request, context, continuation);
        }
    }
}
