using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Simulacrum.API.Database;
using Simulacrum.API.Database.Models;
using Simulacrum.API.Infrastructure.Startup;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console(formatProvider: null)
	.CreateBootstrapLogger();

try
{
	var builder = WebApplication.CreateBuilder(args);
	_ = builder.Configuration.AddJsonFile("secrets.json", optional: true);

	builder.Host.ConfigureSerilog();

	var connectionString = builder.Configuration.GetConnectionString("Default");
	_ = builder.Services.AddDbContext<SimulacrumDbContext>(o => o.UseSqlServer(connectionString));
	_ = builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
						.AddIdentityCookies()
						.ApplicationCookie!.Configure(o => o.Events = new CookieAuthenticationEvents()
						{
							OnRedirectToLogin = ctx =>
							{
								ctx.Response.StatusCode = 401;
								return Task.CompletedTask;
							}
						});

	_ = builder.Services.AddAuthorizationBuilder();
	_ = builder.Services.AddIdentityCore<User>()
						.AddEntityFrameworkStores<SimulacrumDbContext>()
						.AddApiEndpoints();

	_ = builder.Services.Configure<ApiBehaviorOptions>(o => o.SuppressConsumesConstraintForFormFileParameters = true);
	_ = builder.Services.AddHttpContextAccessor();
	_ = builder.Services.AutoRegisterFromSimulacrumAPI();
	_ = builder.Services.AddEndpointsApiExplorer();
	_ = builder.Services.AddSwagger();
	_ = builder.Services.AddAntiforgery();
	_ = builder.Services.AddResponseCompression(o => o.EnableForHttps = true);

	var app = builder.Build();
	_ = app.InitializeDatabase();
	_ = app.MapIdentityApi<User>();
	_ = app.MapSimulacrumAPIEndpoints();
	_ = app.UseDefaultFiles();
	_ = app.UseStaticFiles();
	_ = app.UseSwagger();
	_ = app.UseSwaggerUI();
	_ = app.UseHttpsRedirection();

	_ = app.MapPost("/logout", async (SignInManager<User> signInManager, [FromBody] object empty) =>
	{
		if (empty is not null)
		{
			await signInManager.SignOutAsync();
			return Results.Ok();
		}

		return Results.NotFound();
	}).RequireAuthorization();

	_ = app.MapFallbackToFile("/index.html");
	_ = app.UseRouting();
	_ = app.UseAuthorization();
	_ = app.UseAntiforgery();
	_ = app.UseLogging();

	await app.RunAsync();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
	Log.Fatal(ex, "Unhandled exception");
}
finally
{
	if (new StackTrace().FrameCount == 1)
	{
		Log.Information("Shutdown completed");
		await Log.CloseAndFlushAsync();
	}
}
