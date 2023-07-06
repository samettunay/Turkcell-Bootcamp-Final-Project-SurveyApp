using SurveyApp.DataTransferObjects.Requests;

namespace SurveyApp.Mvc.Models
{
    public class QuestionRequestModel
    {
        public QuestionRequest QuestionRequest { get; set; }
        public QuestionOptionRequest QuestionOptionRequest { get; set; }
    }
}
