using Template.Application.Behaviour.Exceptions.ErrorCode;

namespace Template.Application.Behaviour.Exceptions;

public class ForbiddenException : BaseApplicationException {
	public ForbiddenException() : this("User is not allowed to access entity", ErrorCodes.Default.Forbidden) { }

	public ForbiddenException(Type entityType) : this($"User is not allowed to access {entityType.Name}",
		ErrorCodes.Default.Forbidden) { }

	public ForbiddenException(Type entityType, string id) : this(
		$"User is not allowed to access {entityType.Name} with id {id}") { }

	public ForbiddenException(string message) : this(message, ErrorCodes.Default.Forbidden) { }

	public ForbiddenException(string message, Exception innerException) : base(message, ErrorCodes.Default.Forbidden,
		innerException) { }

	public ForbiddenException(string message, string errorCode) : base(message, errorCode) { }
}