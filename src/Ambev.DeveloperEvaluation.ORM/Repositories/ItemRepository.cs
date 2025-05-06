using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IItemRepository using Entity Framework Core
/// </summary>
public class ItemRepository : IRepositoryAsync<Domain.Entities.Item>
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of ItemRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ItemRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Item in the database
    /// </summary>
    /// <param name="Item">The Item to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Item</returns>
    public async Task<Item> CreateAsync(Item Item, CancellationToken cancellationToken = default)
    {
        await _context.Items.AddAsync(Item, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Item;
    }

    /// <summary>
    /// Retrieves a Item by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Item if found, null otherwise</returns>
    public async Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Items.FirstOrDefaultAsync(o=> o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a Item by their email address
    /// </summary>
    /// <param name="number">The email address to search for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Item if found, null otherwise</returns>
    public async Task<Item?> GetByNumberAsync(string number, CancellationToken cancellationToken = default)
    {
        return await _context.Items
            .FirstOrDefaultAsync(u => u.Number == number, cancellationToken);
    }

    /// <summary>
    /// Deletes a Item from the database
    /// </summary>
    /// <param name="id">The unique identifier of the Item to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Item was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Item = await GetByIdAsync(id, cancellationToken);
        if (Item == null)
            return false;

        _context.Items.Remove(Item);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public Task<IEnumerable<Item>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Item>> Get(Expression<Func<Item, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetOne(Expression<Func<Item, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task Insert(Item entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Item entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task Update(object id, Item entity)
    {
        throw new NotImplementedException();
    }
}
