using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Requests.Products;
using Template.Application.Requests.Products.Commands.CreateProduct;
using Template.Application.Requests.Products.Commands.UpdateProduct;
using Template.Application.Requests.Products.Queries.GetAllProducts;

namespace Template.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/products")]
public class ProductsController : ControllerBase {
	private readonly IMediator _mediator;

	public ProductsController(IMediator mediator) {
		_mediator = mediator;
	}

	[HttpGet]
	[ProducesResponseType(typeof(ICollection<ProductDto>), StatusCodes.Status200OK)]
	public async Task<ICollection<ProductDto>> GetAll([FromQuery] GetAllProductsQuery request,
	                                                  CancellationToken cancellationToken) {
		var result = await _mediator.Send(request, cancellationToken);
		return result;
	}

	[HttpPost]
	[ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
	public async Task<ProductDto> Create(CreateProductCommand request, CancellationToken cancellationToken) {
		var result = await _mediator.Send(request, cancellationToken);
		return result;
	}

	[HttpPut("{id:guid}")]
	[ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
	public async Task<ProductDto> Update(Guid id, UpdateProductCommand request, CancellationToken cancellationToken) {
		request.Id = id;
		var result = await _mediator.Send(request, cancellationToken);
		return result;
	}
}