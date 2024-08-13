using System.Text;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Template.Api.Configuration.Swagger;

// REF: https://github.com/dotnet/aspnet-api-versioning/blob/main/examples/AspNetCore/WebApi/OpenApiExample/ConfigureSwaggerOptions.cs
public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions> {
	private readonly IApiVersionDescriptionProvider _provider;

	public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) {
		_provider = provider;
	}

	public void Configure(SwaggerGenOptions options) {
		foreach (var description in _provider.ApiVersionDescriptions) {
			options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
		}
	}

	private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description) {
		var text = new StringBuilder("Template API");
		var info = new OpenApiInfo {
			Title = "Template API",
			Version = description.ApiVersion.ToString()
		};

		if (description.IsDeprecated) {
			text.Append(" This API version has been deprecated.");
		}

		if (description.SunsetPolicy is not null) {
			var policy = description.SunsetPolicy;
			if (policy.Date is not null) {
				text.Append(" The API will be sunset on ")
				    .Append(policy.Date.Value.Date.ToShortDateString())
				    .Append('.');
			}

			if (policy.HasLinks) {
				text.AppendLine();

				foreach (var link in policy.Links) {
					if (link.Type != "text/html") continue;
					text.AppendLine();

					if (link.Title.HasValue) {
						text.Append(link.Title.Value).Append(": ");
					}

					text.Append(link.LinkTarget.OriginalString);
				}
			}
		}

		info.Description = text.ToString();

		return info;
	}
}