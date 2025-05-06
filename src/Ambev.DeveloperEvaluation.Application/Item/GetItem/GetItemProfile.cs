using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Items.GetItem;

/// <summary>
/// Profile for mapping between Item entity and GetItemResponse
/// </summary>
public class GetItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetItem operation
    /// </summary>
    public GetItemProfile()
    {
        CreateMap <Domain.Entities.Item, GetItemResult>();
    }
}
