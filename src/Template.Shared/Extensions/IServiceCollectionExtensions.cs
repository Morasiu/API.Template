using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Shared.Services.DateTimeProviders;

namespace Template.Shared.Extensions; 

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions {
	public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration) {
		services.AddScoped<IDateTimeProvider, DateTimeProvider>();
		return services;
	}
}