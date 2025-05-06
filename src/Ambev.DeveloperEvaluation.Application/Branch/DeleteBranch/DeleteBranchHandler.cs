using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation;

namespace Ambev.DeveloperEvaluation.Application.Branchs.DeleteBranch;

/// <summary>
/// Handler for processing DeleteBranchCommand requests
/// </summary>
public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, DeleteBranchResponse>
{
    private readonly IRepositoryAsync<Domain.Entities.Branch> _BranchRepository;

    /// <summary>
    /// Initializes a new instance of DeleteBranchHandler
    /// </summary>
    /// <param name="BranchRepository">The Branch repository</param>
    /// <param name="validator">The validator for DeleteBranchCommand</param>
    public DeleteBranchHandler(
        IRepositoryAsync<Domain.Entities.Branch> BranchRepository)
    {
        _BranchRepository = BranchRepository;
    }

    /// <summary>
    /// Handles the DeleteBranchCommand request
    /// </summary>
    /// <param name="request">The DeleteBranch command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteBranchResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteBranchValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        try 
        {
            await _BranchRepository.Delete(request.Id.GetHashCode());
        }
        catch (Exception)
        {
            throw new KeyNotFoundException($"Branch with ID {request.Id} not found");            
        }                            

        return new DeleteBranchResponse { Success = true };
    }
}
