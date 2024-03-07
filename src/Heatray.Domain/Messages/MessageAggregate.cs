using System.Net;
using Heatray.Domain.Abstractions.Models;
using Heatray.Domain.Messages.Enumerations;
using Heatray.Domain.Messages.MessageParts;

namespace Heatray.Domain.Messages;

public class MessageAggregate : AggregateRoot<EntityId, Guid>
{
    private readonly List<SendAttempt> _sendAttempts = new();

    public MessageBase Message { get; private set; } = default!;
    public CorrelationId CorrelationIdentifier { get; private set; } = default!;
    public MessageSender Sender { get; private set; } = default!;
    public MessageBlockade? Blockade { get; private set; }
    public bool WaitsForSend { get; private set; } = true;
    public MessagePriorityEnum Priority { get; private set; }
    public IEnumerable<SendAttempt> SendAttempts => _sendAttempts;

    private MessageAggregate()
    {
    }

    private MessageAggregate(MessageBase message, CorrelationId correlationIdentifier, MessagePriorityEnum priority, MessageSender sender, MessageBlockade? blockade)
    {
        Message = message;
        CorrelationIdentifier = correlationIdentifier;
        Priority = priority;
        Sender = sender;
        Blockade = blockade;
    }

    public static MessageAggregate Create(MessageBase message, CorrelationId correlationIdentifier,
        MessagePriorityEnum priority, MessageSender sender, MessageBlockade? blockade)
    {
        var messageAggregate = new MessageAggregate(message, correlationIdentifier, priority, sender, blockade);
        return messageAggregate;
    }

    public void SetWaitsForSend(bool waitForSend)
    {
        WaitsForSend = waitForSend;
    }

    public void SetSendAttempt(SendAttempt sendAttempt)
    {
        _sendAttempts.Add(sendAttempt);
        if (sendAttempt.StatusCode == HttpStatusCode.OK)
        {
            WaitsForSend = false;
        }
    }

    public void RemoveBlockade()
    {
        Blockade = null;
    }
}