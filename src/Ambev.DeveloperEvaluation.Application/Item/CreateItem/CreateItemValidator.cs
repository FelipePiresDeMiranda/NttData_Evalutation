using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Items.CreateItem;

/// <summary>
/// Validator for CreateItemCommand that defines validation rules for Item creation command.
/// </summary>
public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateItemCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - Number: Required, must be between 3 and 50 characters
    /// - Description: Not empty
    /// - IsActive:  Not empty
    /// - IsTrial:  Not empty    
    /// </remarks>
    public CreateItemCommandValidator()
    {        
        RuleFor(Item => Item.Number).NotEmpty().Length(3, 50);
        RuleFor(Item => Item.Description).NotEmpty();
        RuleFor(Item => Item.IsActive).NotEmpty();        
        RuleFor(Item => Item.IsTrial).NotEmpty();
    }
}