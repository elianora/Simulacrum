namespace Simulacrum.API.Features.Characters.Models;

public sealed record DeathSaves
{
	public bool Success1 { get; set; }
	public bool Success2 { get; set; }
	public bool Success3 { get; set; }
	public bool Failure1 { get; set; }
	public bool Failure2 { get; set; }
	public bool Failure3 { get; set; }
}
