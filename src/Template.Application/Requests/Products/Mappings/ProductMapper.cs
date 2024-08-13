using Template.Persistence.Entities.Products;

namespace Template.Application.Requests.Products.Mappings;

public static class ProductMapper {
	public static ProductDto ToDto(this ProductEntity entity) {
		return new ProductDto {
			Id = entity.Id,
			Name = entity.Name
		};
	}
}