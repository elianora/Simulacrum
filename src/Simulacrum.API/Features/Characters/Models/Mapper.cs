using System.Diagnostics.CodeAnalysis;
using Riok.Mapperly.Abstractions;

namespace Simulacrum.API.Features.Characters.Models;

[Mapper]
internal static partial class Mapper
{
	internal static partial IQueryable<Character> SelectDto(this IQueryable<Database.Models.Character> q);

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static CharacterId ToCharacterId(int id) => (CharacterId)id;
}
