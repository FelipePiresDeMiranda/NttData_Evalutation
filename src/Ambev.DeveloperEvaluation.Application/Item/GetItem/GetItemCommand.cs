using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Items.GetItem;

/// <summary>
/// Command for retrieving a Item by their ID
/// </summary>
public record GetItemCommand : IRequest<GetItemResult>
{
    /// <summary>
    /// The unique identifier of the Item to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetItemCommand
    /// </summary>
    /// <param name="id">The ID of the Item to retrieve</param>
    public GetItemCommand(Guid id)
    {
        Id = id;
    }
}
