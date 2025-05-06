using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// API response model for CreateCustomer operation
/// </summary>
public class CreateCustomerResponse
{
    /// <summary>
    /// The unique identifier of the created Customer
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Customer's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Customer's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The Customer's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    ///// <summary>
    ///// The Customer's role in the system
    ///// </summary>
    //public CustomerRole Role { get; set; }

    ///// <summary>
    ///// The current status of the Customer
    ///// </summary>
    //public CustomerStatus Status { get; set; }
}
