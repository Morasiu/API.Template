using FluentValidation;

namespace Template.Application.Requests.Products.Commands.UpdateProduct; 

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand> {
	public UpdateProductCommandValidator() {
		RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50).NotEmpty();
	}
}