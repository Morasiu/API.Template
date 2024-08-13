namespace Template.Persistence.Entities.Products; 

public class ProductEntity {
	public Guid Id { get; set; }

	public required string Name { get; set; }
}