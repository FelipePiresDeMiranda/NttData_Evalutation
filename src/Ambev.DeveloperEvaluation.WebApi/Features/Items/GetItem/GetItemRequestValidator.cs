using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.GetItem;

/// <summary>
/// Validator for GetItemRequest
/// </summary>
public class GetItemRequestValidator : AbstractValidator<GetItemRequest>
{
    /// <summary>
    /// Initializes validation rules for GetItemRequest
    /// </summary>
    public GetItemRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Item ID is required");
    }
}
