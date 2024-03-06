using Heatray.Domain.Abstractions.Models;
using Heatray.Domain.Messages.Enumerations;
using Heatray.Domain.Messages.MessageParts;

namespace Heatray.Domain.Messages;

public class MessageAggregate : AggregateRoot<EntityId, Guid>
{
    private readonly List<SendAttempt> _sendAttempts = new();

    public Message Message { get; }
    public CorrelationId CorrelationIdentifier { get; }
    public bool WaitsForSend { get; private set; } = true;
    public MessagePriorityEnum Priority { get; }
    public MessageSender Sender { get; }
    public MessageBlockade? Blockade { get; }
    public IEnumerable<SendAttempt> SendAttempts => _sendAttempts;

    public MessageAggregate()
    {
    }
}