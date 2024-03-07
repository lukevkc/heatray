using System.Text.Json.Nodes;
using Heatray.Domain.Abstractions.Models;
using Heatray.Domain.Messages.Enumerations;
using Heatray.Domain.Messages.TypedMessage;

namespace Heatray.Domain.Messages;

public abstract class MessageBase : Entity<EntityId, Guid>
{
    public DateTime? SendDateUtc { get; private set; }
    public MessageTypeEnum Type { get; private set; }

    protected MessageBase()
    {
    }

    public static MessageBase Create(MessageTypeEnum type, JsonObject metadata, DateTime? sendDateUtc = null)
    {
        MessageBase? message = metadata["messageType"]?.ToString() switch
        {
            "Mail" => metadata.GetValue<MailMessage>(),
            "Push" => metadata.GetValue<PushMessage>(),
            "SMS" => metadata.GetValue<SMSMessage>(),
            _ => throw new ArgumentException()
        };
        if (message == null) throw new Exception("Cannot de-serialize message from metadata.");
        message.Type = type;
        message.SendDateUtc = sendDateUtc;

        return message;
    }

    public abstract Task ProcessAsync();
}