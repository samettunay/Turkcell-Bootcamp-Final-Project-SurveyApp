using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Survey, SurveyDisplayResponse>();
            CreateMap<SurveyStatus, SurveyStatusDisplayResponse>();
            CreateMap<Question, QuestionDisplayResponse>();
            CreateMap<QuestionOption, QuestionOptionDisplayResponse>();
            CreateMap<QuestionType, QuestionTypeDisplayResponse>();
            CreateMap<Respondent, RespondentDisplayResponse>();
            CreateMap<Response, SurveyResponseDisplayResponse>();
            CreateMap<Answer, AnswerDisplayResponse>();
            CreateMap<AnswerOption, AnswerOptionDisplayResponse>();

            CreateMap<SurveyRequest, Survey>();
            CreateMap<SurveyStatusRequest, SurveyStatus>();
            CreateMap<SurveyResponseRequest, Response>();
            CreateMap<RespondentRequest, Respondent>();
            CreateMap<QuestionTypeRequest, QuestionType>();
            CreateMap<QuestionRequest, Question>();
            CreateMap<QuestionOptionRequest, QuestionOption>();
            CreateMap<AnswerRequest, Answer>();
            CreateMap<AnswerOptionRequest, AnswerOption>();
        }
    }
}
