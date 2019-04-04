using FrameWork.DAL.Models;
using PlaceholderApiDemo.Library.Services;
using PlaceholderApiDemo.Models.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderApiDemo.Library.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseObject, new()
    {
        protected string baseUrl;
        protected ApiQueryService apiService;
        public BaseRepository(ApiQueryService _apiService, string _baseUrl) {
            baseUrl = _baseUrl;
            apiService = _apiService;
        }
        public virtual int Count => GetAll().Count;

        public virtual TEntity Create(TEntity entity) {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> CreateAsync(TEntity entity) {
            throw new NotImplementedException();
        }

        public virtual int Delete(int id) {
            throw new NotImplementedException();
        }

        public virtual Task<int> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public virtual TEntity Get(int id) {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> GetAsync(int id) {
            return apiService.GetAsync<TEntity>($"{baseUrl}{id}");
        }

        public virtual List<TEntity> Get(Func<TEntity, bool> predicate) {
            return GetAll().Where(predicate).ToList();
        }

        public async Task<List<TEntity>> GetAsync(Func<TEntity, bool> predicate) {
            var entities = await GetAllAsync();
            return entities.Where(predicate).ToList();
        }

        public List<TEntity> GetAll() {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync() {
            return await apiService.GetAsync<List<TEntity>>(baseUrl).ConfigureAwait(false);
        }

        public virtual TEntity Update(TEntity entity) {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity) {
            throw new NotImplementedException();
        }

        #region IDisposable realization
        protected bool _disposed = false;
        protected virtual void Dispose(bool disposing) {
            
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
