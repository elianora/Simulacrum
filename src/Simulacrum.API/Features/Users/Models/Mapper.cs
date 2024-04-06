using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Riok.Mapperly.Abstractions;

namespace Simulacrum.API.Features.Users.Models;

[Mapper]
internal static partial class Mapper
{
	internal static partial IQueryable<User> SelectDto(this IQueryable<Database.Models.User> q);

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static UserId ToUserId(int id) => (UserId)id;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	private static Auth0UserId ToAuth0UserId(string id) => (Auth0UserId)id;

	[SuppressMessage("CodeQuality", "IDE0051: Remove unused private member")]
	[SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance")]
	private static IReadOnlyList<string> ToRoles(string roles) => JsonSerializer.Deserialize<List<string>>(roles)!;

	internal static partial User ToDto(this Database.Models.User user);
}
