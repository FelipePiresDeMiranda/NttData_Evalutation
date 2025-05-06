using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;

/// <summary>
/// API response model for CreateBranch operation
/// </summary>
public class CreateBranchResponse
{
    /// <summary>
    /// The unique identifier of the created Branch
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

    ///// <summary>
    ///// The Branch's role in the system
    ///// </summary>
    //public BranchRole Role { get; set; }

    ///// <summary>
    ///// The current status of the Branch
    ///// </summary>
    //public BranchStatus Status { get; set; }
}
