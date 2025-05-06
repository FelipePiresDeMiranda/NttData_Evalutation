using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Items.CreateItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Items.GetItem;
using Ambev.DeveloperEvaluation.WebApi.Features.Items.DeleteItem;
using Ambev.DeveloperEvaluation.Application.Items.CreateItem;
using Ambev.DeveloperEvaluation.Application.Items.GetItem;
using Ambev.DeveloperEvaluation.Application.Items.DeleteItem;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Items;

/// <summary>
/// Controller for managing Item operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ItemsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Item
    /// </summary>
    /// <param name="request">The Item creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Item details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateItem([FromBody] CreateItemRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateItemCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateItemResponse>
        {
            Success = true,
            Message = "Item created successfully",
            Data = _mapper.Map<CreateItemResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a Item by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Item details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetItemRequest { Id = id };
        var validator = new GetItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetItemCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetItemResponse>
        {
            Success = true,
            Message = "Item retrieved successfully",
            Data = _mapper.Map<GetItemResponse>(response)
        });
    }

    /// <summary>
    /// Deletes a Item by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Item to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the Item was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteItemRequest { Id = id };
        var validator = new DeleteItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteItemCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Item deleted successfully"
        });
    }
}
