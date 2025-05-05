using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;

/// <summary>
/// Handler for processing CreateCustomerCommand requests
/// </summary>
public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly IRepositoryAsync<Domain.Entities.Customer> _CustomerRepository;
    private readonly IMapper _mapper;    

    /// <summary>
    /// Initializes a new instance of CreateCustomerHandler
    /// </summary>
    /// <param name="CustomerRepository">The Customer repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateCustomerCommand</param>
    public CreateCustomerHandler(IRepositoryAsync<Domain.Entities.Customer> CustomerRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _CustomerRepository = CustomerRepository;
        _mapper = mapper;        
    }

    /// <summary>
    /// Handles the CreateCustomerCommand request
    /// </summary>
    /// <param name="command">The CreateCustomer command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Customer details</returns>
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingCustomer = await _CustomerRepository.Get(x => x.Email == command.Email);
        if (existingCustomer != null)
            throw new InvalidOperationException($"Customer with email {command.Email} already exists");

        var Customer = _mapper.Map<Domain.Entities.Customer>(command);        

        await _CustomerRepository.Insert(Customer);
        var result = _mapper.Map<CreateCustomerResult>(Customer);
        return result;
    }
}
