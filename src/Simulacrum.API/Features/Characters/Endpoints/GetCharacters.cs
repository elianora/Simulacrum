using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Simulacrum.API.Database;
using Simulacrum.API.Features.Characters.Models;
using Simulacrum.API.Features.Users.Services;

namespace Simulacrum.API.Features.Characters.Endpoints;

[Handler]
[MapGet("/api/characters")]
[Authorize]
public static partial class GetCharacters
{
	public record Query { }

	public static async ValueTask<IEnumerable<Character>> HandleAsync(
		Query _,
		CurrentUserService userService,
		SimulacrumDbContext dbContext,
		CancellationToken cancellationToken)
	{
		var user = await userService.GetCurrentUser();
		if (user is null)
		{
			return [];
		}

		var characters = await dbContext.Characters
										.Where(character => character.UserId == user.Id)
										.Select(character => new Character())
										.ToListAsync(cancellationToken);

		return characters;
	}
}