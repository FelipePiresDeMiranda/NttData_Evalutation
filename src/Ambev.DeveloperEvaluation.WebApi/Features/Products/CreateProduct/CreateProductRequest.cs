namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new Product in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Gets or sets the Productname. Must be unique and contain only valid characters.
    /// </summary>
    public string Productname { get; set; } = string.Empty;

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
    ///// Gets or sets the initial status of the Product account.
    ///// </summary>
    //public ProductStatus Status { get; set; }

    ///// <summary>
    ///// Gets or sets the role assigned to the Product.
    ///// </summary>
    //public ProductRole Role { get; set; }
}