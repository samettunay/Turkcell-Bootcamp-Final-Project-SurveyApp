using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class SurveyService : BaseService<Survey, SurveyRequest, SurveyDisplayResponse>, ISurveyService
    {
        private readonly ISurveyRepository _repository;
        private readonly IMapper _mapper;
        public ICacheService CacheService { get; }
        public SurveyService(ISurveyRepository repository, IMapper mapper, ICacheService cacheService)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            CacheService = cacheService;
        }

        public override Task<IEnumerable<SurveyDisplayResponse>> GetAllAsync()
        {
            return GetSurveysFromCache();
        }

        private async Task<IEnumerable<SurveyDisplayResponse>> GetSurveysFromCache()
        {
            return await CacheService.GetOrAddAsync("allSurveys", async () =>
            {
                return await base.GetAllAsync();
            });
        }

        public async Task<int> CreateAndReturnIdAsync(SurveyRequest request)
        {
            var survey = _mapper.Map<Survey>(request);
            await _repository.CreateAsync(survey);
            return survey.Id;
        }

        public async Task<IList<SurveyDisplayResponse>> GetSurveysByTypeIdAsync(int surveyTypeId)
        {
            var surveys = await _repository.GetSurveysByTypeIdAsync(surveyTypeId);
            var response = _mapper.Map<IList<SurveyDisplayResponse>>(surveys);
            return response;
        }

        public async Task<bool> SurveyIsExists(int surveyId)
        {
            return await _repository.IsExistsAsync(surveyId);
        }
    }
}
