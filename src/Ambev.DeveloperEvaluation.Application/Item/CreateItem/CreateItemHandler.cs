using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Items.CreateItem;

/// <summary>
/// Handler for processing CreateItemCommand requests
/// </summary>
public class CreateItemHandler : IRequestHandler<CreateItemCommand, CreateItemResult>
{
    private readonly IRepositoryAsync<Domain.Entities.Item> _ItemRepository;
    private readonly IMapper _mapper;    

    /// <summary>
    /// Initializes a new instance of CreateItemHandler
    /// </summary>
    /// <param name="ItemRepository">The Item repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateItemCommand</param>
    public CreateItemHandler(IRepositoryAsync<Domain.Entities.Item> ItemRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _ItemRepository = ItemRepository;
        _mapper = mapper;        
    }

    /// <summary>
    /// Handles the CreateItemCommand request
    /// </summary>
    /// <param name="command">The CreateItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Item details</returns>
    public async Task<CreateItemResult> Handle(CreateItemCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateItemCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingItem = await _ItemRepository.Get(x => x.Number == command.Number);
        if (existingItem != null)
            throw new InvalidOperationException($"Item with Number {command.Number} already exists");

        var Item = _mapper.Map<Domain.Entities.Item>(command);        

        await _ItemRepository.Insert(Item);
        var result = _mapper.Map<CreateItemResult>(Item);
        return result;
    }
}
