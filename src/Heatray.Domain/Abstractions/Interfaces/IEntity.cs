namespace Heatray.Domain.Abstractions.Interfaces;

public interface IEntity
{
    DateTime CreatedOnUtc { get; }
    DateTime? ModifiedOnUtc { get; }

    void SetCreated(DateTime createdOnUtc);
    void SetModified(DateTime modifiedOnUtc);
}