using Ambev.DeveloperEvaluation.Domain;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.ORM.UnitofWork;
using AutoMapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Services
{
    public class GenericServiceAsync<Tv, Te> : IServiceAsync<Tv, Te> where Tv : BaseDomain
                                      where Te : BaseEntity
    {
        protected IUnitofWork _unitOfWork;
        protected IMapper _mapper;

        public int PaginationPagesCnt;

        static ConcurrentDictionary<string, Te> _entitiesCache;
        public GenericServiceAsync(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            // pre-load entity from database as a normal
            // Dictionary with Id as the key, then convert to a thread-safe ConcurrentDictionary
            if (DefaultContext.RespositoryUseThreadSafeDictionary)
                CheckEntitiesCache();
        }

        public GenericServiceAsync()
        {

        }

        public virtual async Task<IEnumerable<Tv>> GetAll()
        {
            if (DefaultContext.RespositoryUseThreadSafeDictionary)
            {
                CheckEntitiesCache();
                // for performance, get from cache
                var entities = await Task.FromResult(_entitiesCache is null ?
                Enumerable.Empty<Te>() : _entitiesCache.Values);
                return _mapper.Map<IEnumerable<Tv>>(source: entities);
            }
            else
            {
                var entities = await _unitOfWork.GetRepositoryAsync<Te>().GetAll();
                return _mapper.Map<IEnumerable<Tv>>(source: entities);
            }
        }

        public virtual async Task<Tv> GetOne(int id)
        {
            if (DefaultContext.RespositoryUseThreadSafeDictionary)
            {
                CheckEntitiesCache();
                _entitiesCache.TryGetValue(id.ToString(), out Te? entity);
                return _mapper.Map<Tv>(source: entity);
            }
            else
            {
                var entity = await _unitOfWork.GetRepositoryAsync<Te>()
                .GetOne(predicate: x => x.Id.GetHashCode() == id);
                return _mapper.Map<Tv>(source: entity);
            }


        }

        public virtual async Task<int> Add(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            await _unitOfWork.GetRepositoryAsync<Te>().Insert(entity);
            int affected = await _unitOfWork.SaveAsync();
            if (DefaultContext.RespositoryUseThreadSafeDictionary && affected == 1)
            {
                CheckEntitiesCache();
                AddCache(entity.Id.ToString(), entity);
            }
            return entity.Id.GetHashCode();
        }

        public async Task<int> Update(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            await _unitOfWork.GetRepositoryAsync<Te>().Update(view.Id, entity);
            int affected = await _unitOfWork.SaveAsync();
            if (DefaultContext.RespositoryUseThreadSafeDictionary && affected == 1)
            {
                CheckEntitiesCache();
                UpdateCache(entity.Id.ToString(), entity);
            }
            return affected;
        }


        public virtual async Task<int> Remove(int id)
        {
            Te entity = await _unitOfWork.Context.Set<Te>().FindAsync(id);
            await _unitOfWork.GetRepositoryAsync<Te>().Delete(id);
            int affected = await _unitOfWork.SaveAsync();
            if (DefaultContext.RespositoryUseThreadSafeDictionary && _entitiesCache is null && affected == 1)
            {
                CheckEntitiesCache();
                _entitiesCache.TryRemove(entity.Id.ToString(), out entity);
            }
            return affected;
        }
        public virtual async Task<IEnumerable<Tv>> Get(Expression<Func<Te, bool>> predicate)
        {
            var items = await _unitOfWork.GetRepositoryAsync<Te>()
                .Get(predicate: predicate);
            return _mapper.Map<IEnumerable<Tv>>(source: items);
        }

        protected Te UpdateCache(string id, Te te)
        {
            Te? old;
            if (_entitiesCache is not null && DefaultContext.RespositoryUseThreadSafeDictionary)
            {
                if (_entitiesCache.TryGetValue(id, out old))
                {
                    if (_entitiesCache.TryUpdate(id, te, old))
                    {
                        return te;
                    }
                }
            }
            return null!;
        }

        protected Te AddCache(string id, Te te)
        {
            Te? old;
            if (_entitiesCache is not null && DefaultContext.RespositoryUseThreadSafeDictionary)
            {
                if (!_entitiesCache.TryGetValue(id, out old))
                {
                    if (_entitiesCache.TryAdd(id, te))
                    {
                        return te;
                    }
                }
                else
                    return old;
            }
            return null!;
        }

        protected void CheckEntitiesCache(bool force = false)
        {
            if (_entitiesCache == null || force)
            {
                _entitiesCache = new ConcurrentDictionary<string, Te>(
                        _unitOfWork.Context.Set<Te>().ToDictionary(e => e.Id.ToString()));
            }
        }

        protected async Task<Te> UpdateEntitiesCache(int id)
        {
            if (_entitiesCache != null)
            {
                var entity = await _unitOfWork.GetRepositoryAsync<Te>().GetOne(predicate: x => x.Id.GetHashCode() == id);
                return UpdateCache(id.ToString(), entity);
            }
            return null;
        }


    }


}

