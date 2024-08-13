using Template.Persistence;

namespace Template.Tests.Shared.Seed;

public static class DbContextExtensions {
	public static async Task<ApplicationDbContext> SeedWithAsync<TSeed>(this ApplicationDbContext context)
		where TSeed : BaseSeed {
		var seeder = (TSeed?) Activator.CreateInstance(typeof(TSeed), context);

		if (seeder is null) throw new InvalidOperationException();

		await seeder.SeedAsync();

		return context;
	}
	
	public static async Task<ApplicationDbContext> SeedWithAsync<TSeed>(this Task<ApplicationDbContext> seedTask)
		where TSeed : BaseSeed {
		var context = await seedTask;
		var seeder = (TSeed?) Activator.CreateInstance(typeof(TSeed), context);

		if (seeder is null) throw new InvalidOperationException();

		await seeder.SeedAsync();

		return context;
	}
}