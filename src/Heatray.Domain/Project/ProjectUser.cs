using Heatray.Domain.Abstractions.Models;

namespace Heatray.Domain.Project;

public class ProjectUser : Entity<EntityId, Guid>
{
    private ProjectUser(EntityId userId, EntityId projectId)
    {
        UserId = userId;
        ProjectId = projectId;
    }

    public EntityId UserId { get; private set; }
    public EntityId ProjectId { get; private set; }

    public static ProjectUser Create(EntityId userId, EntityId projectId)
    {
        return new ProjectUser(userId, projectId);
    }
}