using Grpc.Core;
using Heatray.Api.Protos;

namespace Heatray.Api.gRPC.Services;

public class MessageProcessorService : MessageProcessor.MessageProcessorBase
{
    public override async Task<MessageProcessorReply> ProcessMessage(MessageProcessorRequest request,
        ServerCallContext context)
    {
        var responseModel = new MessageProcessorReply
        {
            Message = $"Hello world from Heatray SERVER! your message: {request.Message}, trace id: {context.RequestHeaders.First(w => w.Key == "correlation-id").Value}",
            CorrelationId = context.RequestHeaders.First(w => w.Key == "correlation-id").Value
        };
        return await Task.FromResult(responseModel);
    }
}