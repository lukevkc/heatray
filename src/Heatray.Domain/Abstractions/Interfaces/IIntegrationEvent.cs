using MediatR;

namespace Heatray.Domain.Abstractions.Interfaces;

public interface IIntegrationEvent : INotification
{
    DateTime OccurredOn { get; }
    Guid Id { get; }

    void SetCorrelationId(Guid correlationId);
}