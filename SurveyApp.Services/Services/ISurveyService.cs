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
        Task<int> CreateAndReturnIdAsync(SurveyRequest request);
    }

}
