using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class AnswerOptionService : BaseService<AnswerOption, AnswerOptionRequest, AnswerOptionDisplayResponse>, IAnswerOptionService
    {
        private readonly IAnswerOptionRepository _repository;
        private readonly IMapper _mapper;
        public AnswerOptionService(IRepository<AnswerOption> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = (IAnswerOptionRepository)repository;
            _mapper = mapper;
        }
    }

}
