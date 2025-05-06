using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

/// <summary>
/// Validator for CreateCustomerCommand that defines validation rules for Customer creation command.
/// </summary>
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateCustomerCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Name: Required, must be between 3 and 50 characters
    /// - Description: Not empty
    /// - IsActive:  Not empty
    /// - IsTrial:  Not empty    
    /// </remarks>
    public CreateCustomerCommandValidator()
    {
        RuleFor(Customer => Customer.Email).SetValidator(new EmailValidator());
        RuleFor(Customer => Customer.Name).NotEmpty().Length(3, 50);
        RuleFor(Customer => Customer.Description).NotEmpty();
        RuleFor(Customer => Customer.IsActive).NotEmpty();
        RuleFor(Customer => Customer.IsTrial).NotEmpty();
    }
}