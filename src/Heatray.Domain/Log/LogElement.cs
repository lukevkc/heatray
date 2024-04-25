using Heatray.Domain.Abstractions.Models;

namespace Heatray.Domain.Log;

public class LogElement : Entity<EntityId, Guid>
{
    public string Header { get; private set; }
    public dynamic Value { get; private set; }

    private LogElement(string header, dynamic value)
    {
        Header = header;
        Value = value;
    }

    public static LogElement Create(string header, dynamic value)
    {
        var logElement = new LogElement(header, value);
        return logElement;
    }
}