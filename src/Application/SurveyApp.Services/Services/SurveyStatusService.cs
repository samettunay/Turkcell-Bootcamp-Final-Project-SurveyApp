﻿using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class SurveyStatusService : BaseService<SurveyStatus, SurveyStatusRequest, SurveyStatusDisplayResponse>, ISurveyStatusService
    {
        private readonly ISurveyStatusRepository _repository;
        private readonly IMapper _mapper;
        public SurveyStatusService(ISurveyStatusRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
