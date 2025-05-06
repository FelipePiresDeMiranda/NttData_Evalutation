using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// Validator for CreateBranchCommand that defines validation rules for Branch creation command.
/// </summary>
public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateBranchCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:    
    /// - Number: Required, must be between 3 and 50 characters
    /// - Description: Not empty
    /// - IsActive:  Not empty
    /// - IsTrial:  Not empty    
    /// </remarks>
    public CreateBranchCommandValidator()
    {        
        RuleFor(Branch => Branch.Name).NotEmpty().Length(3, 50);
        RuleFor(Branch => Branch.Description).NotEmpty();
        RuleFor(Branch => Branch.IsActive).NotEmpty();        
        RuleFor(Branch => Branch.IsTrial).NotEmpty();
    }
}