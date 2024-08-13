namespace Template.Api.Configuration.ServicesValidation; 

public static class ConfigureWebHostBuilderExtensions {
	public static void AddServicesValidationOnStart(this ConfigureHostBuilder host) {
		host.UseDefaultServiceProvider((context, options) => {
			options.ValidateScopes = !context.HostingEnvironment.IsProduction();
			options.ValidateOnBuild = !context.HostingEnvironment.IsProduction();
		});	
	}
}