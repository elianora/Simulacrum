namespace Simulacrum.API.Features.Characters.Models;

public sealed record Class
{
	public ClassName Name { get; set; }
	public ClassLevel Level { get; set; }
}
