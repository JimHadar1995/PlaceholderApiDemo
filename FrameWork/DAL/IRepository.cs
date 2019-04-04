using FrameWork.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderApiDemo.Models.DAL.Abstract
{
    public interface IRepository<TEntity> : IDisposable where TEntity: class, IBaseObject, new()
    {
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        List<TEntity> Get(Func<TEntity, bool> predicate);
        Task<List<TEntity>> GetAsync(Func<TEntity, bool> predicate);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity Create(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
        int Delete(int id);
        Task<int> DeleteAsync(int id);
        int Count { get; }
    }
}
