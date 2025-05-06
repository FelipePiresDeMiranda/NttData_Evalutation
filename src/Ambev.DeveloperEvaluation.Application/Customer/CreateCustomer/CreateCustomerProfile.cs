using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateCustomerProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateCustomerProfile()
    {
        CreateMap<CreateCustomerCommand, User>();
        CreateMap<User, CreateCustomerResult>();
    }
}
