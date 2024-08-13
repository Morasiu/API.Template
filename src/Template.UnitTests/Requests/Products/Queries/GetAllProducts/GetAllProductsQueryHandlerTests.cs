using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Template.Application.Requests.Products.Mappings;
using Template.Application.Requests.Products.Queries.GetAllProducts;
using Template.Tests.Shared.Seed;

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
	public async Task Handle_NoData_ShouldBeSuccess()
	{
		// Arrange
		await ApplicationDbContext.SeedWithAsync<ProductSeed>();
		var products = await ApplicationDbContext.Products.ToListAsync();
		var request = new GetAllProductsQuery();
		var sut = new GetAllProductsQueryHandler(ApplicationDbContext);
		// Act
		var result = await sut.Handle(request, CancellationToken.None);
		// Assert
		result.Should().HaveSameCount(products);
		result.Should().BeEquivalentTo(products.Select(x => x.ToDto()));
	}
}