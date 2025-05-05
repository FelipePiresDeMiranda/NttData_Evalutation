#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.UnitofWork;
//using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// General repository class async
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly IUnitofWork _unitofWork;
        public RepositoryAsync(IUnitofWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _unitofWork.Context.Set<T>().ToListAsync();
        }
        public async Task<IEnumerable<T>> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _unitofWork.Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetOne(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _unitofWork.Context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }
        public async Task Insert(T entity)
        {
            if (entity != null)
                await _unitofWork.Context.Set<T>().AddAsync(entity);
        }
        public async Task Update(object id, T entity)
        {
            if (entity != null)
            {
                //T entitytoUpdate = await _unitOfWork.Context.Set<T>().FindAsync(id);
                //if (entitytoUpdate != null)
                //	_unitOfWork.Context.Entry(entitytoUpdate).CurrentValues.SetValues(entity);
                _unitofWork.Context.Entry(entity).State = EntityState.Modified;
            }
        }
        public async Task Delete(object id)
        {
            T entity = await _unitofWork.Context.Set<T>().FindAsync(id);
            Delete(entity);
        }
        public void Delete(T entity)
        {
            if (entity != null) _unitofWork.Context.Set<T>().Remove(entity);
        }

        //public Task<List<T>> READbyStoredProcedure(string sql, SqlParameter[] parameters)
        //{
        //    return _unitofWork.Context.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
        //}

        //public Task<int> CUDbyStoredProcedure(string sql, SqlParameter[] parameters)
        //{
        //    return _unitofWork.Context.Database.ExecuteSqlRawAsync(sql, parameters);
        //}

    }


}
