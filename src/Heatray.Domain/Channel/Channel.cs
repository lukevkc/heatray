using Heatray.Domain.Abstractions.Models;

namespace Heatray.Domain.Channel;

public class Channel : AggregateRoot<EntityId, Guid>
{
    private Channel(string name, string projectId)
    {
        Name = name;
        ProjectId = EntityId.Init(Guid.Parse(projectId));
    }

    public string Name { get; private set; }
    public EntityId ProjectId { get; private set; }

    public static Channel Create(string name, string projectId)
    {
        return new Channel(name, projectId);
    }
}