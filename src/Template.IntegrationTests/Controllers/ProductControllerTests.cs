using Template.Application.Requests.Products;
using Template.Application.Requests.Products.Commands.CreateProduct;
using Template.Application.Requests.Products.Commands.UpdateProduct;
using Template.Tests.Shared.Generators;

namespace Template.IntegrationTests.Controllers;

public class ProductControllerTests : BaseTest {
	private const string Route = "api/products";

	[Test]
	public async Task Get_WhenDataIsCorrect_ShouldBeOk() {
		// Arrange
		var products = new ProductGenerator().Generate(10);
		ApplicationDbContext.Products.AddRange(products);
		await ApplicationDbContext.SaveChangesAsync();
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
	public async Task Put_WhenEntityNotExist_ShouldReturnNotFound() {
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
	public async Task Put_WhenDataIsCorrect_ShouldReturnOk() {
		// Arrange
		var product = new ProductGenerator().Generate();
		ApplicationDbContext.Products.Add(product);
		await ApplicationDbContext.SaveChangesAsync();
		var request = new UpdateProductCommand {
			Id = product.Id,
			Name = "Test" + Guid.NewGuid()
		};
		// Act
		var response = await HttpClient.PutAsJsonAsync($"{Route}/{request.Id}", request);
		// Assert
		response.Should().Be200Ok();
		var result = await response.Content.DeserializeContentAsync<ProductDto>();
		result.Should().BeEquivalentTo(request, options => options.ExcludingMissingMembers());
	}
}