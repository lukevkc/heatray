using Heatray.Domain.Abstractions.Exceptions;
using Heatray.Domain.Abstractions.Interfaces;
using Marten.Schema;

namespace Heatray.Domain.Abstractions.Models;

public abstract class Entity<TKey, T> : IEquatable<Entity<TKey, T>>, IEntity
    where TKey : StronglyTypedValue<T> where T : IComparable<T>
{
    protected Entity()
    {
    }

    protected Entity(TKey id)
    {
        Id = id;
    }

    public TKey Id { get; set; } = default!;

    [Identity]
    public T AggregateId
    {
        get => Id.Value;
        set { }
    }

    public DateTime CreatedOnUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? ModifiedOnUtc { get; private set; }

    public void SetCreated(DateTime createdOnUtc)
    {
        CreatedOnUtc = createdOnUtc;
    }

    public void SetModified(DateTime modifiedOnUtc)
    {
        ModifiedOnUtc = modifiedOnUtc;
    }

    public bool Equals(Entity<TKey, T>? other)
    {
        return other is not null &&
               (ReferenceEquals(this, other) || (GetType() == other.GetType() && Id.Equals(other.Id)));
    }

    protected void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken()) throw new BusinessRuleValidationException(rule);
    }
}