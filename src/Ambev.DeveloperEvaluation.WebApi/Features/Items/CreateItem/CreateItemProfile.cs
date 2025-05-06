using Ambev.DeveloperEvaluation.Application.Items.CreateItem;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.CreateItem;

/// <summary>
/// Profile for mapping between Application and API CreateItem responses
/// </summary>
public class CreateItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateItem feature
    /// </summary>
    public CreateItemProfile()
    {
        CreateMap<CreateItemRequest, CreateItemCommand>();
        CreateMap<CreateItemResult, CreateItemResponse>();
    }
}
