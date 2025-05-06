using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Branchs.GetBranch;

/// <summary>
/// Handler for processing GetBranchCommand requests
/// </summary>
public class GetBranchHandler : IRequestHandler<GetBranchCommand, GetBranchResult>
{
    private readonly IRepositoryAsync<Domain.Entities.Branch> _BranchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetBranchHandler
    /// </summary>
    /// <param name="BranchRepository">The Branch repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetBranchCommand</param>
    public GetBranchHandler(
        IRepositoryAsync<Domain.Entities.Branch> BranchRepository,
        IMapper mapper)
    {
        _BranchRepository = BranchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetBranchCommand request
    /// </summary>
    /// <param name="request">The GetBranch command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Branch details if found</returns>
    public async Task<GetBranchResult> Handle(GetBranchCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetBranchValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Branch = await _BranchRepository.Get(x => x.Id == request.Id);
        if (Branch == null)
            throw new KeyNotFoundException($"Branch with ID {request.Id} not found");

        return _mapper.Map<GetBranchResult>(Branch);
    }
}
