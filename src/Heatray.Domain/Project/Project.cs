using Heatray.Domain.Abstractions.Models;

namespace Heatray.Domain.Project;

public class Project : AggregateRoot<EntityId, Guid>
{
    private Project(string name, string thumbnail)
    {
        Name = name;
        Thumbnail = thumbnail;
    }

    public string Name { get; private set; }
    public string Thumbnail { get; private set; }
    public ICollection<ProjectUser> ProjectUsers { get; private set; } = new List<ProjectUser>();

    public static Project Create(string name, string thumbnail)
    {
        return new Project(name, thumbnail);
    }
}