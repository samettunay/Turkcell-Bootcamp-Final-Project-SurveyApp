using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;

namespace SurveyApp.Services.Services
{
    public interface IQuestionTypeService : IService<QuestionTypeRequest, QuestionTypeDisplayResponse>
    {
    }

}
