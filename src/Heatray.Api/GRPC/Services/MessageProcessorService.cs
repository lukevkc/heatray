using Grpc.Core;
using Heatray.Api.Protos;

namespace Heatray.Api.GRPC.Services;

public class MessageProcessorService : MessageProcessor.MessageProcessorBase
{
    public override async Task<MessageProcessorReply> ProcessMessage(MessageProcessorRequest request,
        ServerCallContext context)
    {
        var responseModel = new MessageProcessorReply
        {
            Message = "Hello world from Heatray SERVER! " + request.Message,
        };
        return await Task.FromResult(responseModel);
    }
}