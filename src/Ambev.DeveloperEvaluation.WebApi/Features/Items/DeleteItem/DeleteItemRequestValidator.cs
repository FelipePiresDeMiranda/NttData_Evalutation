using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.DeleteItem;

/// <summary>
/// Validator for DeleteItemRequest
/// </summary>
public class DeleteItemRequestValidator : AbstractValidator<DeleteItemRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteItemRequest
    /// </summary>
    public DeleteItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Item ID is required");
    }
}
