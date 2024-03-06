namespace Heatray.Domain.Abstractions.Models;

public class StronglyTypedValue<T> : IEquatable<StronglyTypedValue<T>> where T : IComparable<T>
{
    public StronglyTypedValue()
    {
    }

    public StronglyTypedValue(T value)
    {
        Value = value;
    }

    public T Value { get; } = default!;

    public bool Equals(StronglyTypedValue<T>? other)
    {
        return other is not null &&
               (ReferenceEquals(this, other) || EqualityComparer<T>.Default.Equals(Value, other.Value));
    }

    public override bool Equals(object? obj)
    {
        return obj is not null && (ReferenceEquals(this, obj) ||
                                   (obj.GetType() == GetType() && Equals((StronglyTypedValue<T>)obj)));
    }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Value);
    }

    public static bool operator ==(StronglyTypedValue<T>? left, StronglyTypedValue<T>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(StronglyTypedValue<T>? left, StronglyTypedValue<T>? right)
    {
        return !Equals(left, right);
    }
}