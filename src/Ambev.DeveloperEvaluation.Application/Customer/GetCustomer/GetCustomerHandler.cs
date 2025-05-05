using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Customer.GetCustomer;

/// <summary>
/// Handler for processing GetCustomerCommand requests
/// </summary>
public class GetCustomerHandler : IRequestHandler<GetCustomerCommand, GetCustomerResult>
{
    private readonly IRepositoryAsync<Domain.Entities.Customer> _CustomerRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetCustomerHandler
    /// </summary>
    /// <param name="customerRepository">The Customer repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetCustomerCommand</param>
    public GetCustomerHandler(
        IRepositoryAsync<Domain.Entities.Customer> customerRepository,
        IMapper mapper)
    {
        _CustomerRepository = customerRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCustomerCommand request
    /// </summary>
    /// <param name="request">The GetCustomer command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Customer details if found</returns>
    public async Task<GetCustomerResult> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetCustomerValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Customer = await _CustomerRepository.Get(x => x.Id == request.Id);
        if (Customer == null)
            throw new KeyNotFoundException($"Customer with ID {request.Id} not found");

        return _mapper.Map<GetCustomerResult>(Customer);
    }
}
