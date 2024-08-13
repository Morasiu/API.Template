using Asp.Versioning;

namespace Template.Api.Configuration.ApiVersioning; 

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions {
	public static IServiceCollection AddDefaultApiVersioning(this IServiceCollection services) {
		services.AddApiVersioning(options =>
		{
			options.DefaultApiVersion = new ApiVersion(1, 0);
			options.AssumeDefaultVersionWhenUnspecified = true;
			options.ApiVersionReader = new HeaderApiVersionReader("X-Api-Version");
		}).AddApiExplorer(options =>
		{
			// ReSharper disable once StringLiteralTypo
			options.GroupNameFormat = "'v'VVV";
		});
		return services;
	}
}