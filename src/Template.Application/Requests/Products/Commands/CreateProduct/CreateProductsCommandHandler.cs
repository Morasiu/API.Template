using Template.Application.Requests.Products.Mappings;
using Template.Persistence.Entities.Products;

namespace Template.Application.Requests.Products.Commands.CreateProduct; 

public class CreateProductsCommandHandler : IRequestHandler<CreateProductCommand, ProductDto> {
	private readonly ApplicationDbContext _context;

	public CreateProductsCommandHandler(ApplicationDbContext context) {
		_context = context;
	}

	public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken) {
		var product = new ProductEntity {
			Id = Guid.NewGuid(),
			Name = request.Name
		};
		_context.Products.Add(product);
		await _context.SaveChangesAsync(cancellationToken);
		return product.ToDto();
	}
}