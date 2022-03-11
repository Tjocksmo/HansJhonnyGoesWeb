using HansJhonnyAPI.DataModels;
using HansJhonnyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HansJhonnyAPI.DataBase
{
    public class DataSqlAccess : IDataSqlAccess
    {
        private DbDataContext _dbDataContext;

        public DataSqlAccess(DbDataContext dbDataContext)
        {
            _dbDataContext = dbDataContext;
        }
        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            return await Task.Run(() => predicate is not null
                ? _dbDataContext.Set<T>().Where(predicate).ToList()
                : _dbDataContext.Set<T>().ToList());
        }
        public async Task<T> GetById<T>(int id) where T : class, IId
        {
            return await Task.Run(() =>
            {
                return _dbDataContext.Set<T>().Where(x => x.Id == id).FirstOrDefault() as T;
            });
        }
        public async Task Create<T>(T entity) where T : class
        {
            await _dbDataContext.AddAsync(entity);
            
            await _dbDataContext.SaveChangesAsync();
        }
        public async Task Delete<T>(T entity) where T : class
        {
            _dbDataContext.Remove(entity);
            
            await _dbDataContext.SaveChangesAsync();
        }
        public async Task Update<T>(T entity) where T : class
        {
            await Task.Run(() => { _dbDataContext.Update(entity); });
           
            await _dbDataContext.SaveChangesAsync();
        }
    }
}
