using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        void Create(T entity);
        void Update(T entity);
        void Delete(int id);

        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetWithPredicateAsync(Expression<Func<T, bool>> predicate);

        IList<T> GetAll();
        T GetById(int id);
    }
}
