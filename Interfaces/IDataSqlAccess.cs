using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HansJhonnyAPI.Interfaces
{
    public interface IId
    {
        public int Id { get; }
    }
    public interface IDataSqlAccess
    {        
        //public Task<IEnumerable<T>> GetAsync<T>() where T : class;
        public Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        public Task<T> GetById<T>(int id) where T : class, IId;
        public  Task Create<T>(T entity) where T : class;
        public Task Update<T>(T entity) where T : class;
        public Task Delete<T>(T entity) where T : class;
    }
}
