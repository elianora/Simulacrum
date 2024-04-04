using System.Diagnostics;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Simulacrum.API.Infrastructure.Startup;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console(formatProvider: null)
	.CreateBootstrapLogger();

try
{
	var builder = WebApplication.CreateBuilder(args);
	_ = builder.Configuration.AddJsonFile("secrets.json", optional: true);

	using var container = new Container();
	_ = builder.Host.UseServiceProviderFactory(new DryIocServiceProviderFactory(container));

	builder.Host.ConfigureSerilog();

	_ = builder.Services.Configure<ApiBehaviorOptions>(o => o.SuppressConsumesConstraintForFormFileParameters = true);
	_ = builder.Services.AddHttpContextAccessor();
	_ = builder.Services.AutoRegisterFromSimulacrumAPI();
	_ = builder.Services.AddEndpointsApiExplorer();
	_ = builder.Services.AddSwagger();
	_ = builder.Services.AddAntiforgery();
	_ = builder.Services.AddResponseCompression(o => o.EnableForHttps = true);

	var app = builder.Build();
	_ = app.UseHttpsRedirection();
	_ = app.UseSwagger();
	_ = app.UseSwaggerUI();
	_ = app.UseRouting();
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
