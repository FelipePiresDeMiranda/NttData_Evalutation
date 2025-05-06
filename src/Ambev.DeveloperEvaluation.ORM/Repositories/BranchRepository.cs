using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IBranchRepository using Entity Framework Core
/// </summary>
public class BranchRepository : IRepositoryAsync<Domain.Entities.Branch>
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of BranchRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public BranchRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Branch in the database
    /// </summary>
    /// <param name="Branch">The Branch to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Branch</returns>
    public async Task<Branch> CreateAsync(Branch Branch, CancellationToken cancellationToken = default)
    {
        await _context.Branchs.AddAsync(Branch, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Branch;
    }

    /// <summary>
    /// Retrieves a Branch by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the Branch</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Branch if found, null otherwise</returns>
    public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Branchs.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves a Branch by their name
    /// </summary>
    /// <param name="name">The name of branch</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Branch if found, null otherwise</returns>
    public async Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Branchs
            .FirstOrDefaultAsync(u => u.Name == name, cancellationToken);
    }

    /// <summary>
    /// Deletes a Branch from the database
    /// </summary>
    /// <param name="id">The unique identifier of the Branch to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the Branch was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var Branch = await GetByIdAsync(id, cancellationToken);
        if (Branch == null)
            return false;

        _context.Branchs.Remove(Branch);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public Task<IEnumerable<Branch>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Branch>> Get(Expression<Func<Branch, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<Branch> GetOne(Expression<Func<Branch, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task Insert(Branch entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Branch entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task Update(object id, Branch entity)
    {
        throw new NotImplementedException();
    }
}
