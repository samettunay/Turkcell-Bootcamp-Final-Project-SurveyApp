using SurveyApp.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Services
{
    public interface IService<TRequest, TResponse>
                             where TRequest : class, IDto, new()
                             where TResponse : class, IDto, new()
    {
        Task CreateAsync(TRequest request);
        Task<int> CreateAndReturnIdAsync(TRequest request);
        Task UpdateAsync(TRequest request);
        Task DeleteAsync(int id);

        void Create(TRequest request);
        void Update(TRequest request);
        void Delete(int id);

        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<TResponse> GetByIdAsync(int id);

        IEnumerable<TResponse> GetAll();
        TResponse GetById(int id);
    }
}
