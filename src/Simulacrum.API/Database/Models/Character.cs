namespace Simulacrum.API.Database.Models;

public class Character
{
	public int UserId { get; set; }
	public required User User { get; set; }
	public int CharacterId { get; set; }
}
