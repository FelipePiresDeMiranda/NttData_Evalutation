using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Items.DeleteItem;

/// <summary>
/// Command for deleting a Item
/// </summary>
public record DeleteItemCommand : IRequest<DeleteItemResponse>
{
    /// <summary>
    /// The unique identifier of the Item to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteItemCommand
    /// </summary>
    /// <param name="id">The ID of the Item to delete</param>
    public DeleteItemCommand(Guid id)
    {
        Id = id;
    }
}
