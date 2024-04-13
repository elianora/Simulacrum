using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;
using Simulacrum.API.Database;
using Simulacrum.API.Features.Users.Services;

namespace Simulacrum.API.Features.Characters.Endpoints;

[Handler]
[MapDelete("/api/characters/delete")]
public static partial class DeleteCharacter
{
	public sealed record Query
	{
		public int CharacterId { get; set; }
	}

	private static async ValueTask<bool> HandleAsync(
		Query command,
		CurrentUserService currentUserService,
		SimulacrumDbContext dbContext,
		CancellationToken cancellationToken)
	{
		var user = await currentUserService.GetCurrentUser();
		if (user is null)
		{
			return false;
		}

		var character = await dbContext.Characters.SingleOrDefaultAsync(
			c => c.CharacterId == command.CharacterId && c.UserId == user.Id,
			cancellationToken);

		if (character is null)
		{
			return false;
		}

		_ = dbContext.Characters.Remove(character);
		var result = await dbContext.SaveChangesAsync(cancellationToken);
		return result == 1;
	}
}
