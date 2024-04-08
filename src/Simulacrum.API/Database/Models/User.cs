using Microsoft.AspNetCore.Identity;

namespace Simulacrum.API.Database.Models;

public class User : IdentityUser<int>
{
	public ICollection<Character> Characters { get; init; } = [];
}
