namespace Template.Shared.Services.DateTimeProviders;

internal sealed class DateTimeProvider : IDateTimeProvider {
	public DateTime UtcNow => DateTime.UtcNow;
	public DateTime Now => DateTime.Now;
}