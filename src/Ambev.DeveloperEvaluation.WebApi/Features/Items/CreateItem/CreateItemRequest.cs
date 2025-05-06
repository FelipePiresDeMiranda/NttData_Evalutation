using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.CreateItem;

/// <summary>
/// Represents a request to create a new Item in the system.
/// </summary>
public class CreateItemRequest
{
    /// <summary>
    /// Gets or sets the Itemname. Must be unique and contain only valid characters.
    /// </summary>
    public string Itemname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password. Must meet security requirements.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number in format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address. Must be a valid email format.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    ///// <summary>
    ///// Gets or sets the initial status of the Item account.
    ///// </summary>
    //public ItemStatus Status { get; set; }

    ///// <summary>
    ///// Gets or sets the role assigned to the Item.
    ///// </summary>
    //public ItemRole Role { get; set; }
}