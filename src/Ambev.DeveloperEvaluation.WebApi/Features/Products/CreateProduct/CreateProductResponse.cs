namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// API response model for CreateProduct operation
/// </summary>
public class CreateProductResponse
{
    /// <summary>
    /// The unique identifier of the created Product
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

    ///// <summary>
    ///// The Product's role in the system
    ///// </summary>
    //public ProductRole Role { get; set; }

    ///// <summary>
    ///// The current status of the Product
    ///// </summary>
    //public ProductStatus Status { get; set; }
}
