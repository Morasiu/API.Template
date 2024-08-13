using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Behaviour.Exceptions;

namespace Template.Application.Behaviour;

public class ApplicationExceptionMiddleware {
	private readonly RequestDelegate _next;

	public ApplicationExceptionMiddleware(RequestDelegate next) {
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context) {
		try {
			await _next(context);
		}
		catch (AlreadyExistsException e) {
			await HandleException(context, e, StatusCodes.Status409Conflict);
		}
		catch (ExternalServiceFailureException e) {
			await HandleException(context, e, StatusCodes.Status502BadGateway);
		}
		catch (ForbiddenException e) {
			await HandleException(context, e, StatusCodes.Status403Forbidden);
		}
		catch (NotFoundException e) {
			await HandleException(context, e, StatusCodes.Status404NotFound);
		}
		catch (VerificationException e) {
			await HandleException(context, e, StatusCodes.Status400BadRequest);
		}
	}

	private static async Task HandleException(HttpContext context, BaseApplicationException e, int statusCode) {
		var response = context.Response;
		response.StatusCode = statusCode;
		var details = new ProblemDetails {
			Title = e.ErrorCode,
			Status = statusCode,
			Detail = e.Message
		};
		await response.WriteAsJsonAsync(details);
	}
}