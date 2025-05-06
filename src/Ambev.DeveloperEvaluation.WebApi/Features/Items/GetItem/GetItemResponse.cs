using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.GetItem;

/// <summary>
/// API response model for GetItem operation
/// </summary>
public class GetItemResponse
{
    /// <summary>
    /// The unique identifier of the Item
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
}
