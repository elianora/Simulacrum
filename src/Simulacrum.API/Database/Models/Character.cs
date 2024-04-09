namespace Simulacrum.API.Database.Models;

public class Character
{
	public int UserId { get; set; }
	public required User User { get; set; }
	public int CharacterId { get; set; }

	public string? CharacterName { get; set; }
	public ICollection<Class> Classes { get; init; } = [];
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

	public Skill StrengthSavingThrow { get; set; } = new();
	public Skill DexteritySavingThrow { get; set; } = new();
	public Skill ConstitutionSavingThrow { get; set; } = new();
	public Skill IntelligenceSavingThrow { get; set; } = new();
	public Skill WisdomSavingThrow { get; set; } = new();
	public Skill CharismaSavingThrow { get; set; } = new();

	public Skill Acrobatics { get; set; } = new();
	public Skill AnimalHandling { get; set; } = new();
	public Skill Arcana { get; set; } = new();
	public Skill Athletics { get; set; } = new();
	public Skill Deception { get; set; } = new();
	public Skill History { get; set; } = new();
	public Skill Insight { get; set; } = new();
	public Skill Intimidation { get; set; } = new();
	public Skill Investigation { get; set; } = new();
	public Skill Medicine { get; set; } = new();
	public Skill Nature { get; set; } = new();
	public Skill Perception { get; set; } = new();
	public Skill Performance { get; set; } = new();
	public Skill Persuasion { get; set; } = new();
	public Skill Religion { get; set; } = new();
	public Skill SleightOfHand { get; set; } = new();
	public Skill Stealth { get; set; } = new();
	public Skill Survival { get; set; } = new();

	public int? ArmorClass { get; set; }
	public int? Initiative { get; set; }
	public int? Speed { get; set; }
	public int? HitPointMaximum { get; set; }
	public int? CurrentHitPoints { get; set; }
	public int? TemporaryHitPoints { get; set; }
	public string? HitDice { get; set; }
	public string? HitDiceTotal { get; set; }

	public DeathSaves DeathSaves { get; set; } = new();

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
