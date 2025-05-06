using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.GetItem;

/// <summary>
/// Profile for mapping GetItem feature requests to commands
/// </summary>
public class GetItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetItem feature
    /// </summary>
    public GetItemProfile()
    {
        CreateMap<Guid, Application.Items.GetItem.GetItemCommand>()
            .ConstructUsing(id => new Application.Items.GetItem.GetItemCommand(id));
    }
}
