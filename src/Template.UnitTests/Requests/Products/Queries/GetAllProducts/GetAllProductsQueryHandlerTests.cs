using Template.Application.Requests.Products.Mappings;
using Template.Application.Requests.Products.Queries.GetAllProducts;
using Template.Tests.Shared.Generators;

namespace Template.UnitTests.Requests.Products.Queries.GetAllProducts;

[TestFixture]
public class GetAllProductsQueryHandlerTests : BaseRequestTest
{

	[SetUp]
	public void Setup()
	{
	}

	[TearDown]
	public void TearDown()
	{
	}

	[Test]
	public async Task Handle_WhenEmptyQuery_ShouldBeSuccess()
	{
		// Arrange
		var products = new ProductGenerator().Generate(10);
		ApplicationDbContext.Products.AddRange(products);
		await ApplicationDbContext.SaveChangesAsync();
		var request = new GetAllProductsQuery();
		var sut = new GetAllProductsQueryHandler(ApplicationDbContext);
		// Act
		var result = await sut.Handle(request, CancellationToken.None);
		// Assert
		result.Should().HaveSameCount(products);
		result.Should().BeEquivalentTo(products.Select(x => x.ToDto()));
	}
}