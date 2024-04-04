namespace Simulacrum.API.Database.Models;

public class User
{
	public int UserId { get; set; }
	public string? Auth0UserId { get; set; }
	public required string EmailAddress { get; set; }
	public string? Name { get; set; }
	public bool IsActive { get; set; }
	public DateTimeOffset? LastLogin { get; set; }
	public required string Roles { get; set; }
}
