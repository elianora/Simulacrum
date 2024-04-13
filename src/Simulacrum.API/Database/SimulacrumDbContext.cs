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

		_ = builder.Entity<Character>()
			.OwnsMany(character => character.Classes, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.CharismaSavingThrow, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.ConstitutionSavingThrow, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.DexteritySavingThrow, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.IntelligenceSavingThrow, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.StrengthSavingThrow, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.WisdomSavingThrow, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Acrobatics, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.AnimalHandling, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Arcana, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Athletics, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Deception, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.History, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Insight, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Intimidation, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Investigation, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Medicine, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Nature, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Perception, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Performance, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Persuasion, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Religion, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.SleightOfHand, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Stealth, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.Survival, ownedBuilder => ownedBuilder.ToJson())
			.OwnsOne(character => character.DeathSaves, ownedBuilder => ownedBuilder.ToJson());
	}
}
