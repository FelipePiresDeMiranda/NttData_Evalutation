namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.CreateItem;

/// <summary>
/// API response model for CreateItem operation
/// </summary>
public class CreateItemResponse
{
    /// <summary>
    /// The unique identifier of the created Item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Item's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Item's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The Item's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    ///// <summary>
    ///// The Item's role in the system
    ///// </summary>
    //public ItemRole Role { get; set; }

    ///// <summary>
    ///// The current status of the Item
    ///// </summary>
    //public ItemStatus Status { get; set; }
}
