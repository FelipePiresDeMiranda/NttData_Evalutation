using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

/// <summary>
/// Handler for processing CreateBranchCommand requests
/// </summary>
public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, CreateBranchResult>
{
    private readonly IRepositoryAsync<Domain.Entities.Branch> _BranchRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateBranchHandler
    /// </summary>
    /// <param name="BranchRepository">The Branch repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateBranchCommand</param>
    public CreateBranchHandler(IRepositoryAsync<Domain.Entities.Branch> BranchRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _BranchRepository = BranchRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateBranchCommand request
    /// </summary>
    /// <param name="command">The CreateBranch command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Branch details</returns>
    public async Task<CreateBranchResult> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingBranch = await _BranchRepository.Get(x => x.Name == command.Name);
        if (existingBranch != null)
            throw new InvalidOperationException($"Branch with name {command.Name} already exists");

        var Branch = _mapper.Map<Domain.Entities.Branch>(command);

        await _BranchRepository.Insert(Branch);
        var result = _mapper.Map<CreateBranchResult>(Branch);
        return result;
    }
}
