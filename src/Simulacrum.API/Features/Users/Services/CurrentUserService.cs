using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Simulacrum.API.Database.Models;

namespace Simulacrum.API.Features.Users.Services;

[RegisterScoped]
public sealed class CurrentUserService(
	IAuthorizationService authorizationService,
	IHttpContextAccessor httpContextAccessor,
	UserManager<User> userManager,
	Task<AuthenticationState>? authenticationState = null)
{
	public async ValueTask<User?> GetCurrentUser()
	{
		var claimsPrincipal = await GetClaimsPrincipal();
		if (claimsPrincipal is null)
		{
			return null;
		}

		return await userManager.GetUserAsync(claimsPrincipal);
	}

	public async ValueTask<ClaimsPrincipal?> GetClaimsPrincipal()
	{
		if (httpContextAccessor.HttpContext is { User: { } user })
		{
			return user;
		}

		if (authenticationState is null)
		{
			return null;
		}

		var state = await authenticationState;
		return state.User;
	}

	public async ValueTask<bool> IsAuthorized(string policy)
	{
		if (await GetClaimsPrincipal() is not { } user)
		{
			return false;
		}

		var auth = await authorizationService.AuthorizeAsync(user, policy);
		return auth.Succeeded;
	}
}
