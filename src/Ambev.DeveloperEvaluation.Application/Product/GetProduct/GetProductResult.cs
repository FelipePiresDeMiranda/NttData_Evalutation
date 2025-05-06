namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Response model for GetProduct operation
/// </summary>
public class GetProductResult
{
    /// <summary>
    /// The unique identifier of the Product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Product's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Product's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The Product's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;
}
