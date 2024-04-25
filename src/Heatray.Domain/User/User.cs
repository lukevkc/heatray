using Heatray.Domain.Abstractions.Models;
using Heatray.Domain.Project;

namespace Heatray.Domain.User;

public class User : AggregateRoot<EntityId, Guid>
{
    private User(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public string Username { get; private set; }
    public string Email { get; private set; }
    public ICollection<ProjectUser> ProjectUsers { get; } = new List<ProjectUser>();

    public static User CreateUser(string username, string email)
    {
        return new User(username, email);
    }

    public void AddProject(Project.Project project)
    {
        var projectUser = ProjectUser.Create(Id, project.Id);
        ProjectUsers.Add(projectUser);
    }
}