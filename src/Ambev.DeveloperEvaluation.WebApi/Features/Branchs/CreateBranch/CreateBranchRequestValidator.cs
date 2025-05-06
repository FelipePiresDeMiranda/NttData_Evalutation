using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// Validator for CreateBranchRequest that defines validation rules for Branch creation.
/// </summary>
public class CreateBranchRequestValidator : AbstractValidator<CreateBranchRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateBranchRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be valid format (using EmailValidator)
    /// - Branchname: Required, length between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be Unknown
    /// - Role: Cannot be None
    /// </remarks>
    public CreateBranchRequestValidator()
    {
        RuleFor(Branch => Branch.Email).SetValidator(new EmailValidator());
        RuleFor(Branch => Branch.Branchname).NotEmpty().Length(3, 50);
        RuleFor(Branch => Branch.Password).SetValidator(new PasswordValidator());
        RuleFor(Branch => Branch.Phone).Matches(@"^\+?[1-9]\d{1,14}$");

    }
}