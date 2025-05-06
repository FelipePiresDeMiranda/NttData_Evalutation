using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateBranchProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateBranchProfile()
    {
        CreateMap<CreateBranchCommand, User>();
        CreateMap<User, CreateBranchResult>();
    }
}
