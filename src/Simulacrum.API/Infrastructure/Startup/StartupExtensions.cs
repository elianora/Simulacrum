using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Exceptions.MsSqlServer.Destructurers;
using Serilog.Exceptions.Refit.Destructurers;
using Simulacrum.API.Database;

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

	public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();
		var db = scope.ServiceProvider.GetRequiredService<SimulacrumDbContext>();
		db.Database.Migrate();
		return app;
	}
}
