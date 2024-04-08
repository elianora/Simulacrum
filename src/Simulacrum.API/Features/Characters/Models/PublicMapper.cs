using Riok.Mapperly.Abstractions;

namespace Simulacrum.API.Features.Characters.Models;

[Mapper(UseDeepCloning = true)]
public static partial class PublicMapper
{
	public static partial Character Clone(this Character character);
	public static partial void CloneTo(this Character character, Character target);
}
