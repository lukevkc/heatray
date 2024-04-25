using Heatray.Domain.Abstractions.Models;
using Heatray.Domain.Log.Enumerations;

namespace Heatray.Domain.Log;

public class LogAggregate : AggregateRoot<EntityId, Guid>
{
    public EntityId ChannelId { get; private set; }
    public EntityId ProjectId { get; private set; }
    public string LogMessage { get; private set; }
    public DateTime TimestampUtc { get; private set; }
    public LogTypeEnum LogType { get; private set; }
    public LogLevelEnum LogLevel { get; private set; }
    public List<LogElement> LogElements { get; private set; }

    private LogAggregate(string channelId, string projectId, string logMessage, LogTypeEnum type, LogLevelEnum level, DateTime timestampUtc, List<LogElement> elements)
    {
        ChannelId = EntityId.Init(Guid.Parse(channelId));
        ProjectId = EntityId.Init(Guid.Parse(projectId));
        LogMessage = logMessage;
        TimestampUtc = timestampUtc;
        LogType = type;
        LogLevel = level;
        LogElements = elements;
    }

    public static LogAggregate Create(string channelId, string projectId, string logMessage, LogTypeEnum type, LogLevelEnum level, DateTime timestampUtc, List<LogElement> elements)
    {
        var logAggregate = new LogAggregate(channelId, projectId, logMessage, type, level, timestampUtc, elements);
        return logAggregate;
    }
}