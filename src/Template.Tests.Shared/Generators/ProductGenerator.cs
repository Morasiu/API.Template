using Bogus;
using Template.Persistence.Entities.Products;

namespace Template.Tests.Shared.Generators;

public sealed class ProductGenerator : Faker<ProductEntity> {
	public ProductGenerator() {
		RuleFor(x => x.Id, Guid.NewGuid);
		RuleFor(x => x.Name, f => f.Commerce.ProductName());
	}
}