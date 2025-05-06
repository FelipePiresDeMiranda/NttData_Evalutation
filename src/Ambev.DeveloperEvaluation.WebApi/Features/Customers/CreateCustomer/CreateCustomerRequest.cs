using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// Represents a request to create a new Customer in the system.
/// </summary>
public class CreateCustomerRequest
{
    /// <summary>
    /// Gets or sets the Customername. Must be unique and contain only valid characters.
    /// </summary>
    public string Customername { get; set; } = string.Empty;

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
    ///// Gets or sets the initial status of the Customer account.
    ///// </summary>
    //public CustomerStatus Status { get; set; }

    ///// <summary>
    ///// Gets or sets the role assigned to the Customer.
    ///// </summary>
    //public CustomerRole Role { get; set; }
}