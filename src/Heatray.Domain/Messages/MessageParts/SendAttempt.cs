using System.Net;
using Heatray.Domain.Abstractions.Models;

namespace Heatray.Domain.Messages.MessageParts;

public class SendAttempt : StronglyTypedValue<Guid>
{
    public DateTime DateTimeUtc { get; } = default!;
    public string Exception { get; private set; } = default!;
    public HttpStatusCode StatusCode { get; } = default!;
}