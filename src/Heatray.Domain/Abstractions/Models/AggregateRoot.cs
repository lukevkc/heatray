using System.Collections.Concurrent;
using Heatray.Domain.Abstractions.Interfaces;

namespace Heatray.Domain.Abstractions.Models;

public abstract class AggregateRoot<TKey, T> : Entity<TKey, T>, IAggregateRoot
    where TKey : StronglyTypedValue<T> where T : IComparable<T>
{
    private readonly ConcurrentQueue<IIntegrationEvent> _domainEvents = new();

    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TKey id) : base(id)
    {
    }

    public byte[] Version { get; set; } = Array.Empty<byte>();

    public void AddDomainEvent(IIntegrationEvent eventItem)
    {
        _domainEvents.Enqueue(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public IReadOnlyList<IIntegrationEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }
}