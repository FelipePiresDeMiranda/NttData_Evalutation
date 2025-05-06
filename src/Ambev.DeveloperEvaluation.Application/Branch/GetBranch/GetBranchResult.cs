namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Response model for GetBranch operation
/// </summary>
public class GetBranchResult
{
    /// <summary>
    /// The unique identifier of the Branch
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Branch's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Branch's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The Branch's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;
}
