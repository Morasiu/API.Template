using System.Text.Json.Serialization;

namespace Template.Application.Requests.Products.Commands.UpdateProduct; 

public class UpdateProductCommand : IRequest<ProductDto> {
	[JsonIgnore]
	public Guid Id { get; set; }
	public required string Name { get; set; }
}