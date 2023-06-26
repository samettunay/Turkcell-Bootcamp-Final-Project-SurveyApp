using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class QuestionTypeService : BaseService<QuestionType, QuestionTypeRequest, QuestionTypeDisplayResponse>, IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _repository;
        private readonly IMapper _mapper;
        public QuestionTypeService(IRepository<QuestionType> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = (IQuestionTypeRepository)repository;
            _mapper = mapper;
        }
    }

}
