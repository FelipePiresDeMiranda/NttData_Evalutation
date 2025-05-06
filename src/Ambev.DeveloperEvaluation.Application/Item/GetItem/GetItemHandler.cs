using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Items.GetItem;

/// <summary>
/// Handler for processing GetItemCommand requests
/// </summary>
public class GetItemHandler : IRequestHandler<GetItemCommand, GetItemResult>
{
    private readonly IRepositoryAsync<Domain.Entities.Item> _ItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetItemHandler
    /// </summary>
    /// <param name="ItemRepository">The Item repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetItemCommand</param>
    public GetItemHandler(
        IRepositoryAsync<Domain.Entities.Item> ItemRepository,
        IMapper mapper)
    {
        _ItemRepository = ItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetItemCommand request
    /// </summary>
    /// <param name="request">The GetItem command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Item details if found</returns>
    public async Task<GetItemResult> Handle(GetItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetItemValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Item = await _ItemRepository.Get(x => x.Id == request.Id);
        if (Item == null)
            throw new KeyNotFoundException($"Item with ID {request.Id} not found");

        return _mapper.Map<GetItemResult>(Item);
    }
}
