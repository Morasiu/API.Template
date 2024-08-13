using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Template.Persistence.Entities.Products; 

public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity> {
	public void Configure(EntityTypeBuilder<ProductEntity> builder) {
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
		       .HasMaxLength(1000);
	}
}