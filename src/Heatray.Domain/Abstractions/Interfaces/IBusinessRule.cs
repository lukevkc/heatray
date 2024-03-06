namespace Heatray.Domain.Abstractions.Interfaces;

public interface IBusinessRule
{
    string Message { get; }
    bool IsBroken();
}