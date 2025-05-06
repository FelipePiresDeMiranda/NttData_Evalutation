namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.GetItem;

/// <summary>
/// Request model for getting a Item by ID
/// </summary>
public class GetItemRequest
{
    /// <summary>
    /// The unique identifier of the Item to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
