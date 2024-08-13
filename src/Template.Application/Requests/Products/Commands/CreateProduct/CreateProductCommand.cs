namespace Template.Application.Requests.Products.Commands.CreateProduct; 

public class CreateProductCommand : IRequest<ProductDto> {
	public required string Name { get; set; }
}