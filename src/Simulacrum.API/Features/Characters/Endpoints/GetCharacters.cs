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
	public sealed record Query { }

	private static async ValueTask<IEnumerable<Character>> HandleAsync(
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

		// TODO: Why does this not work with the IQueryable .SelectDto extension?
		return await dbContext.Characters
						.Where(character => character.UserId == user.Id)
						//.SelectDto()
						.Select(character => character.ToDto())
						.ToListAsync(cancellationToken);
	}
}
