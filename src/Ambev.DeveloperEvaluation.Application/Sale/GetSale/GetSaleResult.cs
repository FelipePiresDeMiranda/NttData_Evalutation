namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the Sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Sale's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Sale's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The Sale's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;
}
