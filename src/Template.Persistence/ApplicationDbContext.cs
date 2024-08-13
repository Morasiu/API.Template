using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Template.Persistence.Entities.Products;

namespace Template.Persistence;

public class ApplicationDbContext : DbContext {
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	public DbSet<ProductEntity> Products => Set<ProductEntity>();

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}