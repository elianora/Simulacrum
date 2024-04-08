using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Simulacrum.API.Database.Models;

namespace Simulacrum.API.Database;

public class SimulacrumDbContext(DbContextOptions<SimulacrumDbContext> options) : IdentityDbContext<User, Role, int>(options)
{
	public DbSet<Character> Characters { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		_ = builder.Entity<User>()
			.HasMany(user => user.Characters)
			.WithOne(character => character.User)
			.HasForeignKey(character => character.UserId);
	}
}
