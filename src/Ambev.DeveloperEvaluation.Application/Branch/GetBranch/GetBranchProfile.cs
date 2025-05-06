using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Profile for mapping between Branch entity and GetBranchResponse
/// </summary>
public class GetBranchProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetBranch operation
    /// </summary>
    public GetBranchProfile()
    {
        CreateMap<Domain.Entities.Branch, GetBranchResult>();
    }
}
