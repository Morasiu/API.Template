using Microsoft.EntityFrameworkCore;
using Template.Application.Behaviour.Exceptions;
using Template.Application.Requests.Products.Mappings;
using Template.Persistence.Entities.Products;

namespace Template.Application.Requests.Products.Commands.UpdateProduct; 

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto> {
	private readonly ApplicationDbContext _context;

	public UpdateProductCommandHandler(ApplicationDbContext context) {
		_context = context;
	}

	public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken) {
		var product = await _context.Products
		                            .AsTracking()
		                            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

		if (product is null) throw new NotFoundException(typeof(ProductEntity), request.Id.ToString());
		
		product.Name = request.Name;
		await _context.SaveChangesAsync(cancellationToken);
		return product.ToDto();
	}
}