using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.CreateItem;

/// <summary>
/// Validator for CreateItemRequest that defines validation rules for Item creation.
/// </summary>
public class CreateItemRequestValidator : AbstractValidator<CreateItemRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateItemRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Itemname: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public CreateItemRequestValidator()
    {
        RuleFor(Item => Item.Email).SetValidator(new EmailValidator());
        RuleFor(Item => Item.Itemname).NotEmpty().Length(3, 50);
        RuleFor(Item => Item.Password).SetValidator(new PasswordValidator());
        RuleFor(Item => Item.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        
    }
}