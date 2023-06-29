using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class RespondentService : BaseService<Respondent, RespondentRequest, RespondentDisplayResponse>, IRespondentService
    {
        private readonly IRespondentRepository _repository;
        private readonly IMapper _mapper;
        public RespondentService(IRespondentRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }

}
