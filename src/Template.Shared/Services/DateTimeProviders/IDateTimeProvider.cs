namespace Template.Shared.Services.DateTimeProviders; 

public interface IDateTimeProvider {
	DateTime UtcNow { get; }
	DateTime Now { get; }
}