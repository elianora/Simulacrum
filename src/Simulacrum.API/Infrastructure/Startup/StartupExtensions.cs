using System.Globalization;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Metadata;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Exceptions.MsSqlServer.Destructurers;
using Serilog.Exceptions.Refit.Destructurers;

namespace Simulacrum.API.Infrastructure.Startup;

public static class StartupExtensions
{
	public static void ConfigureSerilog(this IHostBuilder host)
		=> host.UseSerilog((ctx, lc) => lc
			.MinimumLevel.Information()
			.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
			.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
			.MinimumLevel.Override("System.Net.Http.HttpClient.Refit.Implementation", LogEventLevel.Warning)
			.Enrich.FromLogContext()
			.Enrich.WithEnvironmentName()
			.Enrich.WithThreadId()
			.Enrich.WithProperty("ExecutionId", Guid.NewGuid())
			.Enrich.WithExceptionDetails(
				new DestructuringOptionsBuilder()
				.WithDefaultDestructurers()
				.WithDestructurers(
				[
					new DbUpdateExceptionDestructurer(),
					new SqlExceptionDestructurer(),
					new ApiExceptionDestructurer(),
				])
			)
			.WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
		);

	public static IServiceCollection AddSwagger(this IServiceCollection services) =>
		services.AddSwaggerGen(o =>
		{
			o.CustomSchemaIds(t => t.FullName?.Replace('+', '.'));

			o.DocInclusionPredicate((_, api) =>
				api.ActionDescriptor
					.EndpointMetadata
					.OfType<IRouteDiagnosticsMetadata>()
					.FirstOrDefault()
					is { Route: var route }
				&& route.StartsWith("/api", StringComparison.OrdinalIgnoreCase)
			);

			o.TagActionsBy(api =>
			{
				var routeMetadata = api.ActionDescriptor
					.EndpointMetadata
					.OfType<IRouteDiagnosticsMetadata>()
					.FirstOrDefault();

				if (routeMetadata is not { Route: var route })
					throw new InvalidOperationException("Unable to determine tag for endpoint.");

				var splits = route["/api/".Length..].Split('/');
				if (splits is not [{ } tag, ..]
					|| string.IsNullOrWhiteSpace(tag))
				{
					throw new InvalidOperationException("Unable to determine tag for endpoint.");
				}

				return [tag[..1].ToUpperInvariant() + tag[1..]];
			});
		});

	public static IApplicationBuilder UseLogging(this IApplicationBuilder app) =>
		app.UseSerilogRequestLogging(o =>
		{
			o.GetLevel = static (httpContext, _, _) =>
				httpContext.Response.StatusCode >= 500 ? LogEventLevel.Error :
				httpContext.Request.Path.StartsWithSegments(new("/api"), StringComparison.OrdinalIgnoreCase) ? LogEventLevel.Verbose :
				LogEventLevel.Information;

			o.EnrichDiagnosticContext = static (diagnosticContext, httpContext) =>
			{
				diagnosticContext.Set("User", httpContext.User?.Identity?.Name);
				diagnosticContext.Set("RemoteIP", httpContext.Connection.RemoteIpAddress);
				diagnosticContext.Set("ConnectingIP", httpContext.Request.Headers["CF-Connecting-IP"]);
			};
		});

	public static IEndpointRouteBuilder MapAccountServices(this IEndpointRouteBuilder app)
	{
		_ = app
			.MapGet("/Login", async (HttpContext context, string returnUrl = "/") =>
			{
				var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
					.WithRedirectUri(returnUrl)
					.Build();

				await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
			});

		_ = app
			.MapGet("/Logout", async (HttpContext context, string returnUrl = "/") =>
			{
				var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
					.WithRedirectUri(returnUrl)
					.Build();

				await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
				await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			})
			.RequireAuthorization();

		return app;
	}
}
