using Grpc.Core;
using Heatray.Api.Protos;

namespace Heatray.Api.gRPC.Services;

public class LogProcessorService : LogProcessor.LogProcessorBase
{
    public override async Task<LogProcessorReply> ProcessLog(LogProcessorRequest request,
        ServerCallContext context)
    {
        var responseModel = new LogProcessorReply
        {
            Log = $"Hello world from Heatray SERVER! your log: {request.Log}, trace id: {context.RequestHeaders.First(w => w.Key == "correlation-id").Value}",
            CorrelationId = context.RequestHeaders.First(w => w.Key == "correlation-id").Value
        };
        return await Task.FromResult(responseModel);
    }
}