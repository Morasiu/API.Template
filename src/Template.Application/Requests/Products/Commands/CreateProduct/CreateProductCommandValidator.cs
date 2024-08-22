using FluentValidation;

namespace Template.Application.Requests.Products.Commands.CreateProduct; 

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand> {
	public CreateProductCommandValidator() {
		RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50).NotEmpty();
	}
}