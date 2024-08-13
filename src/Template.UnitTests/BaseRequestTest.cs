using Template.Persistence;
using Template.UnitTests.Factories;

namespace Template.UnitTests; 

public abstract class BaseRequestTest {
	protected ApplicationDbContext ApplicationDbContext { get; private set; } = null!;

	[SetUp]
	public void BaseSetup()
	{
		ApplicationDbContext = DbContextFactory.Create();
	}

	[TearDown]
	public virtual async Task BaseTearDown()
	{
		await ApplicationDbContext.DisposeAsync();
	}
}