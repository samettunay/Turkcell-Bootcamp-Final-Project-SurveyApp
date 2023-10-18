using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class SurveyTypeService : BaseService<SurveyType, SurveyTypeRequest, SurveyTypeDisplayResponse>, ISurveyTypeService
    {
        private readonly ISurveyTypeRepository _repository;
        private readonly IMapper _mapper;
        public SurveyTypeService(ISurveyTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
