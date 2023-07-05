using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurveyApp.DataTransferObjects;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Services
{
    public class BaseService<TEntity, TRequest, TResponse> : IService<TRequest, TResponse>
                            where TRequest : class, IDto, new()
                            where TResponse : class, IDto, new()
                            where TEntity : class, IEntity, new()

    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(TRequest request)
        {
            var mappedRequest = _mapper.Map<TEntity>(request);
            _repository.Create(mappedRequest);
        }

        public async Task CreateAsync(TRequest request)
        {
            var mappedRequest = _mapper.Map<TEntity>(request);
            await _repository.CreateAsync(mappedRequest);
        }

        public async Task<int> CreateAndReturnIdAsync(TRequest request)
        {
            var mappedRequest = _mapper.Map<TEntity>(request);
            await _repository.CreateAsync(mappedRequest);
            return mappedRequest.Id;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var items = _repository.GetAll();
            var response = _mapper.Map<IEnumerable<TResponse>>(items);
            return response;
        }

        public async Task<IEnumerable<TResponse>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<TResponse>>(items);
            return response;
        }

        public TResponse GetById(int id)
        {
            var item = _repository.GetById(id);
            return _mapper.Map<TResponse>(item);
        }

        public async Task<TResponse> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<TResponse>(item);
        }

        public void Update(TRequest request)
        {
            var mappedRequest = _mapper.Map<TEntity>(request);
            _repository.Update(mappedRequest);
        }

        public async Task UpdateAsync(TRequest request)
        {
            var mappedRequest = _mapper.Map<TEntity>(request);
            await _repository.UpdateAsync(mappedRequest);
        }
    }
}
