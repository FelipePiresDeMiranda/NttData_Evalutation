using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

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
