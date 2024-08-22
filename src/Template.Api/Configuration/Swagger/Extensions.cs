using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.Filters;

namespace Template.Api.Configuration.Swagger;

public static class Extensions {
	public static IServiceCollection AddSwagger(this IServiceCollection services) {
		services.ConfigureOptions<ConfigureSwaggerOptions>();
		services.AddSwaggerGen(opt => {
			opt.ExampleFilters();
			opt.OperationFilter<SwaggerDefaultValues>();
			opt.SupportNonNullableReferenceTypes();
		});
		services.AddFluentValidationRulesToSwagger();
		services.AddSwaggerExamplesFromAssemblyOf<IApiMarker>();
		return services;
	}

	public static void UseSwaggerUi(this WebApplication app) {
		app.UseSwagger();
		app.UseSwaggerUI(options => {
			var descriptions = app.DescribeApiVersions();

			// build a swagger endpoint for each discovered API version
			foreach (var description in descriptions) {
				var url = $"/swagger/{description.GroupName}/swagger.json";
				var name = description.GroupName.ToUpperInvariant();
				options.SwaggerEndpoint(url, name);
			}
		});
	}
}