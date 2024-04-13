namespace Simulacrum.API.Features.Characters.Models;

public sealed record Skill
{
	public bool HasProficiency { get; set; }
	public bool HasExpertise { get; set; }
	public SkillScore Score { get; set; }
}
