using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for Product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - Number: Required, must be between 3 and 50 characters
    /// - Description: Not empty
    /// - IsActive:  Not empty
    /// - IsTrial:  Not empty    
    /// </remarks>
    public CreateProductCommandValidator()
    {        
        RuleFor(Product => Product.Sku).NotEmpty().Length(3, 50);
        RuleFor(Product => Product.Description).NotEmpty();
        RuleFor(Product => Product.IsActive).NotEmpty();        
        RuleFor(Product => Product.IsTrial).NotEmpty();
    }
}