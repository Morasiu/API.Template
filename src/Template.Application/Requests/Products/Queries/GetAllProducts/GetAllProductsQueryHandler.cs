using Microsoft.EntityFrameworkCore;
using Template.Application.Requests.Products.Mappings;

namespace Template.Application.Requests.Products.Queries.GetAllProducts; 

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ICollection<ProductDto>> {
	private readonly ApplicationDbContext _context;

	public GetAllProductsQueryHandler(ApplicationDbContext context) {
		_context = context;
	}
	
	
	public async Task<ICollection<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) {
		var products = await _context.Products.Select(x => x.ToDto()).ToListAsync(cancellationToken);
		return products;
	}
}