using System.Diagnostics.CodeAnalysis;
using Riok.Mapperly.Abstractions;
using Simulacrum.API.Features.Characters.Endpoints;

namespace Simulacrum.API.Features.Characters.Models;

[Mapper]
internal static partial class Mapper
{
	internal static partial IQueryable<Character> SelectDto(this IQueryable<Database.Models.Character> q);
	internal static partial Character ToDto(this Database.Models.Character c);

	[MapperIgnoreTarget(nameof(Database.Models.Character.User))]
	[MapperIgnoreTarget(nameof(Database.Models.Character.UserId))]
	internal static partial Database.Models.Character ToEntityFromCreateCommand(this CreateCharacter.Command c);

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static CharacterId ToCharacterId(int id) => (CharacterId)id;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static ClassName ToClassName(string name) => (ClassName)name;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static ClassLevel ToClassLevel(int level) => (ClassLevel)level;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static ExperiencePoints ToExperiencePoints(int experience) => (ExperiencePoints)experience;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static AbilityScore ToAbilityScore(int score) => (AbilityScore)score;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static ProficiencyBonus ToProficiencyBonus(int bonus) => (ProficiencyBonus)bonus;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static ArmorClass ToArmorClass(int ac) => (ArmorClass)ac;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static InitiativeScore ToInitiativeScore(int score) => (InitiativeScore)score;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static Speed ToSpeed(int speed) => (Speed)speed;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static HitPoints ToHitPoints(int hp) => (HitPoints)hp;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static HitDice ToHitDice(string hitDice) => (HitDice)hitDice;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static LongformText ToLongformText(string text) => (LongformText)text;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static Currency ToCurrency(int currency) => (Currency)currency;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static SkillScore ToSkillScore(int score) => (SkillScore)score;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static Name ToName(string name) => (Name)name;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static Background ToBackground(string background) => (Background)background;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static Race ToRace(string race) => (Race)race;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static Alignment ToAlignment(string alignment) => (Alignment)alignment;
}
