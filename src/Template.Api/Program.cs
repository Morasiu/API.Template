using Serilog;
using Template.Api.Configuration.ApiVersioning;
using Template.Api.Configuration.HealthChecks;
using Template.Api.Configuration.JsonSerilizer;
using Template.Api.Configuration.Logging;
using Template.Api.Configuration.ServicesValidation;
using Template.Api.Configuration.Swagger;
using Template.Application.Extensions;
using Template.Infrastructure.Extensions;
using Template.Shared.Extensions;

Log.Logger = new LoggerConfiguration()
             .WriteTo.Console()
             .CreateLogger();

Log.Information("Starting up");

try {
	RunApplication();
}


catch (Exception ex) {
	Log.Fatal(ex, "Unhandled exception");
}
finally {
	Log.Information("Shut down complete");
	Log.CloseAndFlush();
}


void RunApplication() {
	var builder = WebApplication.CreateBuilder(args);
	// Logging
	builder.Host.UseSerilog((ctx, lc) => lc
	                                     .Enrich.FromLogContext()
	                                     .WriteTo.Console()
	                                     .ReadFrom.Configuration(ctx.Configuration));
	// Add services to the container.
	builder.Services.AddShared(builder.Configuration);
	builder.Services.AddApplication(builder.Configuration);
	builder.Services.AddInfrastructure(builder.Configuration);
	builder.Services.AddDefaultHealthChecks(builder.Configuration);
	builder.Services.AddControllers().AddJsonOptions(x => x.AddDefaultOptions());
	builder.Services.AddDefaultApiVersioning();
	builder.Services.AddCors();
	builder.Services.AddSwagger();
	builder.Host.AddServicesValidationOnStart();

	var app = builder.Build();
	app.UseCors(policyBuilder =>
	{
		policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
	app.UseSerilogRequestLogging(options =>
	{
		options.GetLevel = LogHelper.ExcludeHealthChecks;
	});
	app.UseApplication();
	// Configure the HTTP request pipeline.
	if (!app.Environment.IsProduction()) {
		app.UseSwaggerUi();
	}
	app.MapHealthChecks();
	app.MapControllers();
	app.Run();
}