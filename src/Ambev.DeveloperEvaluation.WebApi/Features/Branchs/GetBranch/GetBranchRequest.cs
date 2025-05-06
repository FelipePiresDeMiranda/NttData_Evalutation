namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs.GetBranch;

/// <summary>
/// Request model for getting a Branch by ID
/// </summary>
public class GetBranchRequest
{
    /// <summary>
    /// The unique identifier of the Branch to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
