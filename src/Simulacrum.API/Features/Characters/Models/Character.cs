using System.Diagnostics.CodeAnalysis;

namespace Simulacrum.API.Features.Characters.Models;

public sealed record Character
{
	public CharacterId CharacterId { get; set; }

	public Name CharacterName { get; set; }

	// Suppress this because we need it to be deep cloneable
	[SuppressMessage("Usage", "CA2227: Collection properties should be read only")]
	public ICollection<Class> Classes { get; set; } = [];

	public Background Background { get; set; }
	public Name PlayerName { get; set; }
	public Race Race { get; set; }
	public Alignment Alignment { get; set; }
	public ExperiencePoints ExperiencePoints { get; set; }

	public AbilityScore Strength { get; set; }
	public AbilityScore Dexterity { get; set; }
	public AbilityScore Constitution { get; set; }
	public AbilityScore Intelligence { get; set; }
	public AbilityScore Wisdom { get; set; }
	public AbilityScore Charisma { get; set; }

	public ProficiencyBonus ProficiencyBonus { get; set; }
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

	public ArmorClass ArmorClass { get; set; }
	public InitiativeScore Initiative { get; set; }
	public Speed Speed { get; set; }
	public HitPoints HitPointMaximum { get; set; }
	public HitPoints CurrentHitPoints { get; set; }
	public HitPoints TemporaryHitPoints { get; set; }
	public HitDice HitDice { get; set; }
	public HitDice HitDiceTotal { get; set; }

	public DeathSaves DeathSaves { get; set; } = new();

	public LongformText PersonalityTraits { get; set; }
	public LongformText Ideals { get; set; }
	public LongformText Bonds { get; set; }
	public LongformText Flaws { get; set; }

	public LongformText OtherProficienciesAndLanguages { get; set; }
	public LongformText AttacksAndSpellcasting { get; set; }
	public Currency CopperPieces { get; set; }
	public Currency SilverPieces { get; set; }
	public Currency ElectrumPieces { get; set; }
	public Currency GoldPieces { get; set; }
	public Currency PlatinumPieces { get; set; }
	public LongformText Equipment { get; set; }
	public LongformText FeaturesAndTraits { get; set; }
}
