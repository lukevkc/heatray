namespace Heatray.Domain.Abstractions.Interfaces;

public interface IAggregateRoot : IEntity
{
    byte[] Version { get; }
    void AddDomainEvent(IIntegrationEvent eventItem);
    IReadOnlyList<IIntegrationEvent> GetDomainEvents();
    void ClearDomainEvents();
}