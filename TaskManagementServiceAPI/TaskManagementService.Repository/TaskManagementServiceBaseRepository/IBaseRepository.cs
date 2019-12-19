using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace TaskManagementService.Repository.TaskManagementServiceBaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        DbRawSqlQuery<T> SQLQuery<T>(string sql, params object[] parameters);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T GetByID(object id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
