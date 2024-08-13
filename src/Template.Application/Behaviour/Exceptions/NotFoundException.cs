using Template.Application.Behaviour.Exceptions.ErrorCode;

namespace Template.Application.Behaviour.Exceptions;

public class NotFoundException : BaseApplicationException {
	public NotFoundException() : this("Entity not found", ErrorCodes.Default.NotFound) { }
	public NotFoundException(Type entityType) : this($"{entityType.Name} not found", ErrorCodes.Default.NotFound) { }

	public NotFoundException(Type entityType, string id) : this($"{entityType.Name} not found with id {id}",
		ErrorCodes.Default.NotFound) { }

	public NotFoundException(string message, Exception innerException) : base(message, ErrorCodes.Default.NotFound,
		innerException) { }

	public NotFoundException(string message) : base(message, ErrorCodes.Default.NotFound) { }
	public NotFoundException(string message, string errorCode) : base(message, errorCode) { }
}