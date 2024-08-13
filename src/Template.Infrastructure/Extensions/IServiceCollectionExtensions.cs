using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Services.Emails;
using Template.Infrastructure.Services.Emails;

namespace Template.Infrastructure.Extensions; 

// ReSharper disable once InconsistentNaming
public static class IServiceCollectionExtensions {
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
		services.AddScoped<IEmailService, EmailService>();
		return services;
	}
}