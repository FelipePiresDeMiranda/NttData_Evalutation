using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Items.DeleteItem;

/// <summary>
/// Validator for DeleteItemCommand
/// </summary>
public class DeleteItemValidator : AbstractValidator<DeleteItemCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteItemCommand
    /// </summary>
    public DeleteItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Item ID is required");
    }
}
