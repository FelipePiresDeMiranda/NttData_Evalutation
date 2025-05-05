using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {        
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;

        DefaultContext Context { get; }
        int Save();
        Task<int> SaveAsync();
    }

    public interface IUnitofWork<TContext> : IUnitofWork where TContext : DbContext
    {
    }

    public class UnitofWork : IUnitofWork
    {
        public DefaultContext Context { get; }

        private Dictionary<Type, object> _repositoriesAsync;        
        private bool _disposed;

        public UnitofWork(DefaultContext context)
        {
            Context = context;
            _disposed = false;
        }        

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            _repositoriesAsync = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositoriesAsync.ContainsKey(type)) _repositoriesAsync[type] = new RepositoryAsync<TEntity>(this);
            return (IRepositoryAsync<TEntity>)_repositoriesAsync[type];
        }

        public int Save()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }
        public async Task<int> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
    }

    public class Pagination
    {
        public int Page { get; set; } = 1;
        public int QuantityPerPage { get; set; } = 10;
    }
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, Pagination pagination, out int pagesCnt)
        {
            double count = queryable.Count();
            pagesCnt = (int)Math.Ceiling(count / pagination.QuantityPerPage);
            return queryable
                .Skip((pagination.Page - 1) * pagination.QuantityPerPage)
                .Take(pagination.QuantityPerPage);
        }

    }

}
