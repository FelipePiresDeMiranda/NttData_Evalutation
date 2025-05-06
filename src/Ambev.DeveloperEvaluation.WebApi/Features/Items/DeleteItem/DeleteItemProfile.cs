using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items.DeleteItem;

/// <summary>
/// Profile for mapping DeleteItem feature requests to commands
/// </summary>
public class DeleteItemProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteItem feature
    /// </summary>
    public DeleteItemProfile()
    {
        CreateMap<Guid, Application.Items.DeleteItem.DeleteItemCommand>()
            .ConstructUsing(id => new Application.Items.DeleteItem.DeleteItemCommand(id));
    }
}
