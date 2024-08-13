using Template.Persistence;

namespace Template.Tests.Shared.Seed; 

public abstract class BaseSeed
{
	protected readonly ApplicationDbContext Context;

	public BaseSeed(ApplicationDbContext context)
	{
		Context = context;
	}
	public abstract Task SeedAsync();
}