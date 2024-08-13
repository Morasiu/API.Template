using Template.Application.Requests.Products;
using Template.Application.Requests.Products.Commands.CreateProduct;
using Template.Application.Requests.Products.Commands.UpdateProduct;
using Template.Tests.Shared.Seed;

namespace Template.IntegrationTests.Controllers;

public class ProductControllerTests : BaseTest {
	private const string Route = "api/products";

	[Test]
	public async Task Get_WhenDataIsCorrect_ShouldBeOk() {
		// Arrange
		await ApplicationDbContext.SeedWithAsync<ProductSeed>();
		var products = await ApplicationDbContext.Products.ToListAsync();
		// Act
		var response = await HttpClient.GetAsync(Route);
		// Assert
		response.Should().Be200Ok();
		var result = await response.Content.DeserializeContentAsync<IEnumerable<ProductDto>>();
		result.Should().BeEquivalentTo(products, options => options.ExcludingMissingMembers());
	}

	[Test]
	public async Task Post_WhenDataIsCorrect_ShouldBeOk() {
		// Arrange
		var request = new CreateProductCommand {
			Name = "Test"
		};
		// Act
		var response = await HttpClient.PostAsJsonAsync(Route, request);
		// Assert
		response.Should().Be200Ok();
		var result = await response.Content.DeserializeContentAsync<ProductDto>();
		result.Should().BeEquivalentTo(request, options => options.ExcludingMissingMembers());
	}

	[Test]
	public async Task Put_WhenEntityNotExist_ShouldBeOk() {
		// Arrange
		var request = new UpdateProductCommand {
			Name = "Test"
		};
		// Act
		var response = await HttpClient.PutAsJsonAsync($"{Route}/{Guid.NewGuid()}", request);
		// Assert
		response.Should().Be404NotFound();
	}

	[Test]
	public async Task Put_WhenDataIsCorrect_ShouldBeOk() {
		// Arrange
		await ApplicationDbContext.SeedWithAsync<ProductSeed>();
		var product = await ApplicationDbContext.Products.FirstAsync();
		var request = new UpdateProductCommand {
			Id = product.Id,
			Name = Guid.NewGuid().ToString().Substring(0, 10)
		};
		// Act
		var response = await HttpClient.PutAsJsonAsync($"{Route}/{request.Id}", request);
		// Assert
		response.Should().Be200Ok();
		var result = await response.Content.DeserializeContentAsync<ProductDto>();
		result.Should().BeEquivalentTo(request, options => options.ExcludingMissingMembers());
	}
}