using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateProductCommand requests
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IRepositoryAsync<Domain.Entities.Product> _ProductRepository;
    private readonly IMapper _mapper;    

    /// <summary>
    /// Initializes a new instance of CreateProductHandler
    /// </summary>
    /// <param name="ProductRepository">The Product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateProductCommand</param>
    public CreateProductHandler(IRepositoryAsync<Domain.Entities.Product> ProductRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;        
    }

    /// <summary>
    /// Handles the CreateProductCommand request
    /// </summary>
    /// <param name="command">The CreateProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Product details</returns>
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingProduct = await _ProductRepository.Get(x => x.SKU == command.Sku);
        if (existingProduct != null)
            throw new InvalidOperationException($"Product with Number {command.Sku} already exists");

        var Product = _mapper.Map<Domain.Entities.Product>(command);        

        await _ProductRepository.Insert(Product);
        var result = _mapper.Map<CreateProductResult>(Product);
        return result;
    }
}
