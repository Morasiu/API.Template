using Template.Application.Requests.Products.Commands.CreateProduct;

namespace Template.UnitTests.Requests.Products.Commands.CreateProduct;

[TestFixture]
public class CreateProductCommandHandlerTests : BaseRequestTest {
	[SetUp]
	public void Setup() { }

	[TearDown]
	public void TearDown() { }

	[Test]
	public async Task Handle_WhenDateIsCorrect_ShouldBeSuccess() {
		// Arrange
		var request = new CreateProductCommand {
			Name = "Product Name"
		};
		var sut = new CreateProductsCommandHandler(ApplicationDbContext);
		// Act
		var result = await sut.Handle(request, CancellationToken.None);
		// Assert
		result.Id.Should().NotBeEmpty();
		result.Should().BeEquivalentTo(request);
	}
}