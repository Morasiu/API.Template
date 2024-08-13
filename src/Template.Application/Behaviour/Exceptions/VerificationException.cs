using Template.Application.Behaviour.Exceptions.ErrorCode;

namespace Template.Application.Behaviour.Exceptions;

public class VerificationException : BaseApplicationException {
	public VerificationException() : this("Cannot process entity", ErrorCodes.Default.VerificationError) { }

	public VerificationException(Type entityType) : this($"Cannot process {entityType.Name}",
		ErrorCodes.Default.VerificationError) { }

	public VerificationException(Type entityType, string id) : this(
		$"Cannot process entity {entityType.Name} with id {id}", ErrorCodes.Default.VerificationError) { }

	public VerificationException(string message, Exception innerException) : base(message,
		ErrorCodes.Default.VerificationError, innerException) { }

	public VerificationException(string message) : base(message, ErrorCodes.Default.VerificationError) { }
	public VerificationException(string message, string errorCode) : base(message, errorCode) { }
}