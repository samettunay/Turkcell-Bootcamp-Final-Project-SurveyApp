using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Services
{
    public class SurveyService : BaseService<Survey, SurveyRequest, SurveyDisplayResponse>, ISurveyService
    {
        private readonly ISurveyRepository _repository;
        private readonly IMapper _mapper;
        public SurveyService(IRepository<Survey> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = (ISurveyRepository)repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAndReturnIdAsync(SurveyRequest request)
        {
            var survey = _mapper.Map<Survey>(request);
            await _repository.CreateAsync(survey);
            return survey.Id;
        }
    }
}
