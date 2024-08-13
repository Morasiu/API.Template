namespace Template.Application.Behaviour.Exceptions;

public abstract class BaseApplicationException : Exception {
	public string ErrorCode { get; }

	protected BaseApplicationException(string message, string errorCode) : base(message) {
		ErrorCode = errorCode;
	}

	protected BaseApplicationException(string message, string errorCode, Exception innerException) : base(message, innerException) {
		ErrorCode = errorCode;
	}
}