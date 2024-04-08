using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Simulacrum.API.Database.Models;
using Simulacrum.API.Features.Users.Services;

namespace Simulacrum.API.Features.Users.Endpoints;

[Handler]
[MapGet("/api/users/current")]
[Authorize]
public static partial class GetCurrentUser
{
	public sealed record Query { }

	private static async ValueTask<User?> HandleAsync(
		Query _,
		CurrentUserService currentUserService,
		UserManager<User> userManager,
		CancellationToken __)
	{
		var currentUserPrincipal = await currentUserService.GetCurrentUser();
		if (currentUserPrincipal is null)
		{
			return null;
		}

		var user = await userManager.GetUserAsync(currentUserPrincipal);
		return user;
	}
}
