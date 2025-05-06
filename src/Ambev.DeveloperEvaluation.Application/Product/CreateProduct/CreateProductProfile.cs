using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<CreateProductCommand, User>();
        CreateMap<User, CreateProductResult>();
    }
}
