using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation;

namespace Ambev.DeveloperEvaluation.Application.Items.DeleteItem;

/// <summary>
/// Handler for processing DeleteItemCommand requests
/// </summary>
public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, DeleteItemResponse>
{
    private readonly IRepositoryAsync<Domain.Entities.Item> _ItemRepository;

    /// <summary>
    /// Initializes a new instance of DeleteItemHandler
    /// </summary>
    /// <param name="ItemRepository">The Item repository</param>
    /// <param name="validator">The validator for DeleteItemCommand</param>
    public DeleteItemHandler(
        IRepositoryAsync<Domain.Entities.Item> ItemRepository)
    {
        _ItemRepository = ItemRepository;
    }

    /// <summary>
    /// Handles the DeleteItemCommand request
    /// </summary>
    /// <param name="request">The DeleteItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteItemResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        try 
        {
            await _ItemRepository.Delete(request.Id.GetHashCode());
        }
        catch (Exception)
        {
            throw new KeyNotFoundException($"Item with ID {request.Id} not found");            
        }                            

        return new DeleteItemResponse { Success = true };
    }
}
