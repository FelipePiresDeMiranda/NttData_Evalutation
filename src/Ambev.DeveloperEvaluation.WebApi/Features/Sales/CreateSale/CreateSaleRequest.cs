using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the Salename. Must be unique and contain only valid characters.
    /// </summary>
    public string Salename { get; set; } = string.Empty;

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
    ///// Gets or sets the initial status of the Sale account.
    ///// </summary>
    //public SaleStatus Status { get; set; }

    ///// <summary>
    ///// Gets or sets the role assigned to the Sale.
    ///// </summary>
    //public SaleRole Role { get; set; }
}