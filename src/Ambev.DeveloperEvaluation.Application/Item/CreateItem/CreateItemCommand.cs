using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Items.CreateItem;

/// <summary>
/// Command for creating a new Item.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Item, 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateItemResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateItemCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateItemCommand : IRequest<CreateItemResult>
{
    /// <summary>
    /// Gets or sets the number of the Item to be created.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the Item to be created.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets if this is a trial Item.
    /// </summary>
    public bool IsTrial { get; set; }

    /// <summary>
    /// Gets or sets if the Item is active.
    /// </summary>
    public bool IsActive { get; set; }


    public ValidationResultDetail Validate()
    {
        var validator = new CreateItemCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}