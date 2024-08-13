# Behaviour 

## Exceptions
 Here should be all basic exceptions and logic to map these to specific HTTP code i.e.

> `NotFoundException` -> `HTTP 404`

Add new exceptions here if needed (remember to add new case to [ApplicationExceptionMiddleware](../ApplicationExceptionMiddleware.cs).

See [Error code](./ErrorCode/README.md) for info about error codes.

### Details
* `AlreadyExistException` - throw if client tries to add entity which already exist or update some data which would cause a conflict
* `ExternalServiceFailure` - throw if external service returns error or stopped responding i.e. email service or file storage service
* `ForbiddenException` - throw if entry cannot be returned or modified by specific user i.e. user tries to access data from different user
* `NotFoundException` - throw if user tries access, modify or delete on entity that does not exist
* `VerificationException` - throw if operation cannot proceed due to current system status i.e. user cannot add new user to organisation because organisation user limit is exceeded