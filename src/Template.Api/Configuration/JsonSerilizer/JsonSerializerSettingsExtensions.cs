using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Template.Api.Configuration.JsonSerilizer; 

public static class JsonSerializerSettingsExtensions {
	public static void AddDefaultOptions(this JsonOptions options)
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	}
}