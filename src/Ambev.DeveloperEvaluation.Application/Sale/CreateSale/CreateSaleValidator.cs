using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - Number: Required, must be between 3 and 50 characters
    /// - Description: Not empty
    /// - IsActive:  Not empty
    /// - IsTrial:  Not empty    
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(Sale => Sale.Number).NotEmpty().Length(3, 50);
        RuleFor(Sale => Sale.Description).NotEmpty();
        RuleFor(Sale => Sale.IsActive).NotEmpty();
        RuleFor(Sale => Sale.IsTrial).NotEmpty();
    }
}