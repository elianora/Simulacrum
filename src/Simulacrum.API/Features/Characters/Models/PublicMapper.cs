using Riok.Mapperly.Abstractions;
using Simulacrum.API.Features.Characters.Endpoints;

namespace Simulacrum.API.Features.Characters.Models;

[Mapper(UseDeepCloning = true)]
public static partial class PublicMapper
{
	public static partial Character Clone(this Character character);
	public static partial void CloneTo(this Character character, Character target);

	[MapperIgnoreTarget(nameof(Database.Models.Character.User))]
	[MapperIgnoreTarget(nameof(Database.Models.Character.UserId))]
	public static partial void CloneTo(this UpdateCharacter.Command command, Database.Models.Character character);
}
