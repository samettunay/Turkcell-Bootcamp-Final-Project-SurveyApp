using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class QuestionService : BaseService<Question, QuestionRequest, QuestionDisplayResponse>, IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;
        public QuestionService(IRepository<Question> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = (IQuestionRepository)repository;
            _mapper = mapper;
        }
    }
}
