using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Authorization;
using Simulacrum.API.Database;
using Simulacrum.API.Features.Characters.Models;
using Simulacrum.API.Features.Users.Services;

namespace Simulacrum.API.Features.Characters.Endpoints;

[Handler]
[MapPost("/api/characters/create")]
[Authorize]
public static partial class CreateCharacter
{
	public sealed record Command
	{
		public string? CharacterName { get; set; }
		public IReadOnlyList<CommandClass> Classes { get; set; } = [];
		public string? Background { get; set; }
		public string? PlayerName { get; set; }
		public string? Race { get; set; }
		public string? Alignment { get; set; }
		public int? ExperiencePoints { get; set; }

		public int? Strength { get; set; }
		public int? Dexterity { get; set; }
		public int? Constitution { get; set; }
		public int? Intelligence { get; set; }
		public int? Wisdom { get; set; }
		public int? Charisma { get; set; }

		public int? ProficiencyBonus { get; set; }
		public bool JackOfAllTrades { get; set; }

		public CommandSkill StrengthSavingThrow { get; set; } = new();
		public CommandSkill DexteritySavingThrow { get; set; } = new();
		public CommandSkill ConstitutionSavingThrow { get; set; } = new();
		public CommandSkill IntelligenceSavingThrow { get; set; } = new();
		public CommandSkill WisdomSavingThrow { get; set; } = new();
		public CommandSkill CharismaSavingThrow { get; set; } = new();

		public CommandSkill Acrobatics { get; set; } = new();
		public CommandSkill AnimalHandling { get; set; } = new();
		public CommandSkill Arcana { get; set; } = new();
		public CommandSkill Athletics { get; set; } = new();
		public CommandSkill Deception { get; set; } = new();
		public CommandSkill History { get; set; } = new();
		public CommandSkill Insight { get; set; } = new();
		public CommandSkill Intimidation { get; set; } = new();
		public CommandSkill Investigation { get; set; } = new();
		public CommandSkill Medicine { get; set; } = new();
		public CommandSkill Nature { get; set; } = new();
		public CommandSkill Perception { get; set; } = new();
		public CommandSkill Performance { get; set; } = new();
		public CommandSkill Persuasion { get; set; } = new();
		public CommandSkill Religion { get; set; } = new();
		public CommandSkill SleightOfHand { get; set; } = new();
		public CommandSkill Stealth { get; set; } = new();
		public CommandSkill Survival { get; set; } = new();

		public int? ArmorClass { get; set; }
		public int? Initiative { get; set; }
		public int? Speed { get; set; }
		public int? HitPointMaximum { get; set; }
		public int? CurrentHitPoints { get; set; }
		public int? TemporaryHitPoints { get; set; }
		public string? HitDice { get; set; }
		public string? HitDiceTotal { get; set; }

		public CommandDeathSaves DeathSaves { get; set; } = new();

		public string? PersonalityTraits { get; set; }
		public string? Ideals { get; set; }
		public string? Bonds { get; set; }
		public string? Flaws { get; set; }

		public string? OtherProficienciesAndLanguages { get; set; }
		public string? AttacksAndSpellcasting { get; set; }
		public int? CopperPieces { get; set; }
		public int? SilverPieces { get; set; }
		public int? ElectrumPieces { get; set; }
		public int? GoldPieces { get; set; }
		public int? PlatinumPieces { get; set; }
		public string? Equipment { get; set; }
		public string? FeaturesAndTraits { get; set; }
	}

	public sealed record CommandClass
	{
		public string? Name { get; set; }
		public int? Level { get; set; }
	}

	public sealed record CommandSkill
	{
		public bool HasProficiency { get; set; }
		public bool HasExpertise { get; set; }
		public int? Score { get; set; }
	}

	public sealed record CommandDeathSaves
	{
		public bool Success1 { get; set; }
		public bool Success2 { get; set; }
		public bool Success3 { get; set; }
		public bool Failure1 { get; set; }
		public bool Failure2 { get; set; }
		public bool Failure3 { get; set; }
	}

	private static async ValueTask<Character?> HandleAsync(
		Command command,
		CurrentUserService currentUserService,
		SimulacrumDbContext dbContext,
		CancellationToken cancellationToken)
	{
		var user = await currentUserService.GetCurrentUser();
		if (user is null)
		{
			return null;
		}

		var newCharacter = command.ToEntityFromCreateCommand();
		newCharacter.User = user;
		newCharacter.UserId = user.Id;

		_ = dbContext.Characters.Add(newCharacter);
		_ = dbContext.SaveChangesAsync(cancellationToken);

		return newCharacter.ToDto();
	}
}
