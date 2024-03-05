namespace Heatray.Infrastructure.Configuration;

public class AuthConfiguration
{
    public const string Section = "AuthConfiguration";
    public string AccessSecret { get; init; } = default!;
}