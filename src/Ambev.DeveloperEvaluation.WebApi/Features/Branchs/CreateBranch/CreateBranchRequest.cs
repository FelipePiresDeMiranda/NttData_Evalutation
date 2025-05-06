namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// Represents a request to create a new Branch in the system.
/// </summary>
public class CreateBranchRequest
{
    /// <summary>
    /// Gets or sets the Branchname. Must be unique and contain only valid characters.
    /// </summary>
    public string Branchname { get; set; } = string.Empty;

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
    ///// Gets or sets the initial status of the Branch account.
    ///// </summary>
    //public BranchStatus Status { get; set; }

    ///// <summary>
    ///// Gets or sets the role assigned to the Branch.
    ///// </summary>
    //public BranchRole Role { get; set; }
}