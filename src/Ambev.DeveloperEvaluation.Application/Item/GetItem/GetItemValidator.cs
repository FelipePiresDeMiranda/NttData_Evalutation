using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Items.GetItem;

/// <summary>
/// Validator for GetItemCommand
/// </summary>
public class GetItemValidator : AbstractValidator<GetItemCommand>
{
    /// <summary>
    /// Initializes validation rules for GetItemCommand
    /// </summary>
    public GetItemValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Item ID is required");
    }
}
