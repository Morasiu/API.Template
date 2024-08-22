using Template.Application.Behaviour.Exceptions;
using Template.Application.Requests.Products.Commands.UpdateProduct;
using Template.Tests.Shared.Generators;

namespace Template.UnitTests.Requests.Products.Commands.UpdateProduct;

[TestFixture]
public class UpdateProductCommandHandlerTests : BaseRequestTest {
	[SetUp]
	public void Setup() { }

	[TearDown]
	public void TearDown() { }

	[Test]
	public async Task Handle_WhenDataIsCorrect_ShouldBeSuccess() {
		// Arrange
		var product = new ProductGenerator().Generate();
		ApplicationDbContext.Products.Add(product);
		await ApplicationDbContext.SaveChangesAsync();
		var request = new UpdateProductCommand {
			Id = product.Id,
			Name = "Product Name"
		};
		var sut = new UpdateProductCommandHandler(ApplicationDbContext);
		// Act
		var result = await sut.Handle(request, CancellationToken.None);
		// Assert
		result.Id.Should().NotBeEmpty();
		result.Should().BeEquivalentTo(request);
	}
	
	[Test]
	public async Task Handle_WhenEntityDoNotExtist_ShouldThrowNotFoundException() {
		// Arrange
		var request = new UpdateProductCommand {
			Id = Guid.NewGuid(),
			Name = "Product Name"
		};
		var sut = new UpdateProductCommandHandler(ApplicationDbContext);
		// Act
		var action = () => sut.Handle(request, CancellationToken.None);
		// Assert
		await action.Should().ThrowAsync<NotFoundException>();
	}
}