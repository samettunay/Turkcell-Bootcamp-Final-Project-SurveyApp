using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class AnswerService : BaseService<Answer, AnswerRequest, AnswerDisplayResponse>, IAnswerService
    {
        private readonly IAnswerRepository _repository;
        private readonly IMapper _mapper;
        public AnswerService(IRepository<Answer> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = (IAnswerRepository)repository;
            _mapper = mapper;
        }
    }
}
