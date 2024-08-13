using Template.Application.Behaviour.Exceptions.ErrorCode;

namespace Template.Application.Behaviour.Exceptions;

public class AlreadyExistsException : BaseApplicationException {
	public AlreadyExistsException() : this("Entity already exists", ErrorCodes.Default.AlreadyExist) { }

	public AlreadyExistsException(string message) : this(message, ErrorCodes.Default.AlreadyExist) { }

	public AlreadyExistsException(Type entityType) : this($"{entityType.Name} already exists",
		ErrorCodes.Default.AlreadyExist) { }

	public AlreadyExistsException(Type entityType, string id) : base(
		$"{entityType.Name} with id {id} already exists", ErrorCodes.Default.AlreadyExist) { }
	
	public AlreadyExistsException(string message, string errorCode) : base(message, errorCode) { }

	public AlreadyExistsException(string message, Exception innerException) : base(message,
		ErrorCodes.Default.AlreadyExist, innerException) { }
}