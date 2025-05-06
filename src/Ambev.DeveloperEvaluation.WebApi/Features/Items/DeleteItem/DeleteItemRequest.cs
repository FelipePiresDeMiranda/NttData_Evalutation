namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.DeleteItem;

/// <summary>
/// Request model for deleting a Item
/// </summary>
public class DeleteItemRequest
{
    /// <summary>
    /// The unique identifier of the Item to delete
    /// </summary>
    public Guid Id { get; set; }
}
