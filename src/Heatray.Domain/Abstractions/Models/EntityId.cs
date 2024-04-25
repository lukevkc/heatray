namespace Heatray.Domain.Abstractions.Models;

public class EntityId : StronglyTypedValue<Guid>
{
    public EntityId()
    {
    }

    private EntityId(Guid value) : base(value)
    {
    }

    public static EntityId Empty => new(Guid.Empty);

    public static EntityId Create()
    {
        return new EntityId(Guid.NewGuid());
    }

    public static EntityId Init(Guid value)
    {
        return new EntityId(value);
    }

    public static implicit operator Guid(EntityId userId)
    {
        return userId.Value;
    }

    public static implicit operator EntityId(Guid userId)
    {
        return Init(userId);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}