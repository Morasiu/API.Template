using Template.Application.Services.Emails;

namespace Template.Infrastructure.Services.Emails; 

public class EmailService : IEmailService {
	public Task SendEmail() {
		return Task.CompletedTask;
	}
}