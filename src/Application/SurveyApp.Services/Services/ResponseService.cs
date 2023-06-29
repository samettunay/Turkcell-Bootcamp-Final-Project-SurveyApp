using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class ResponseService : BaseService<Response, SurveyResponseRequest, SurveyResponseDisplayResponse>, IResponseService
    {
        private readonly IResponseRepository _repository;
        private readonly IMapper _mapper;
        public ResponseService(IResponseRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }

}
