using System.Data.Common;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Respawn;
using Template.Api;
using Template.Persistence;
using Template.Shared.Services.DateTimeProviders;
using Template.Tests.Shared.Services.DateTimeProviders;

namespace Template.IntegrationTests;

public class TemplateApiWebApplicationFactory : WebApplicationFactory<IApiMarker> {
	private readonly PostgreSqlTestcontainer _dbContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
	                                                             .WithDatabase(
		                                                             new PostgreSqlTestcontainerConfiguration(
			                                                             "postgres:14.7-alpine3.17") {
			                                                             Database = "application",
			                                                             Username = "postgres",
			                                                             Password = "password"
		                                                             })
	                                                             .Build();


	public HttpClient HttpClient { get; private set; } = default!;
	private DbConnection _dbConnection = default!;
	private Respawner _respawner = default!;

	public async Task ResetDatabase() {
		await _respawner.ResetAsync(_dbConnection);
	}

	public async Task InitializeAsync() {
		await _dbContainer.StartAsync();
		HttpClient = CreateClient();
		await InitializeRespawner();
	}

	// ReSharper disable once IdentifierTypo
	private async Task InitializeRespawner() {
		_dbConnection = new NpgsqlConnection(_dbContainer.ConnectionString);
		await _dbConnection.OpenAsync();
		_respawner = await Respawner.CreateAsync(_dbConnection, new RespawnerOptions {
			DbAdapter = DbAdapter.Postgres,
			WithReseed = true,
			SchemasToInclude = new[] {
				"public"
			}
		});
	}

	public override async ValueTask DisposeAsync() {
		await base.DisposeAsync();
		await _dbConnection.CloseAsync();
		await _dbContainer.StopAsync();
	}


	protected override void ConfigureWebHost(IWebHostBuilder builder) {
		base.ConfigureWebHost(builder);

		var config = new ConfigurationBuilder()
		             .AddInMemoryCollection(new Dictionary<string, string?> {
			             ["ConnectionStrings:Default"] = _dbContainer.ConnectionString
		             })
		             .Build();
		builder.UseConfiguration(config);

		// Doesn't work in .Net 6: https://github.com/dotnet/aspnetcore/issues/37680
		// builder.ConfigureAppConfiguration((configBuilder) =>
		// {
		//     configBuilder.AddInMemoryCollection();
		// });
		base.ConfigureWebHost(builder);
		builder.ConfigureAppConfiguration(configBuilder => {
			configBuilder.AddInMemoryCollection(
				new Dictionary<string, string?> {
					["Serilog:MinimumLevel:Override:Microsoft"] = "Warning"
				});
		});

		builder.ConfigureServices(services => {
			var sp = services.BuildServiceProvider();
			
			using var scope = sp.CreateScope();
			var scopedServices = scope.ServiceProvider;
			var db = scopedServices.GetRequiredService<ApplicationDbContext>();
			db.Database.Migrate();
		});

		builder.ConfigureTestServices(services => {
			services.RemoveAll<IDateTimeProvider>();
			services.AddSingleton<IDateTimeProvider, TestDateTimeProvider>();
		});
	}
}