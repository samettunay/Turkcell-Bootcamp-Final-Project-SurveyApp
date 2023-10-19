using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Services
{
    public interface ISurveyService : IService<SurveyRequest, SurveyDisplayResponse>
    {
        Task<IList<SurveyDisplayResponse>> GetSurveysByTypeIdAsync(int surveyTypeId);
        Task<int> CreateAndReturnIdAsync(SurveyRequest request);
        Task<bool> SurveyIsExists(int surveyId);
    }

}
