using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Items.CreateItem;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateItemProfile()
    {
        CreateMap<CreateItemCommand, User>();
        CreateMap<User, CreateItemResult>();
    }
}
