﻿using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;

namespace SurveyApp.Services.Services
{
    public class QuestionOptionService : BaseService<QuestionOption, QuestionOptionRequest, QuestionOptionDisplayResponse>, IQuestionOptionService
    {
        private readonly IQuestionOptionRepository _repository;
        private readonly IMapper _mapper;
        public QuestionOptionService(IQuestionOptionRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
