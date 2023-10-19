using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Data
{
    public static class DbSeeding
    {
        public static void SeedDatabase(SurveyDbContext dbContext)
        {
            seedSurveyStatusNotExists(dbContext);
            seedSurveyTypeIfNotExists(dbContext);
            seedSurveyIfNotExists(dbContext);
            seedRespondentNotExists(dbContext);
            seedResponseIfNotExists(dbContext);
            seedQuestionTypeIfNotExists(dbContext);
            seedQuestionIfNotExists(dbContext);
            seedQuestionOptionsIfNotExists(dbContext);
            seedAnswerIfNotExists(dbContext);
            seedAnswerOptionsNotExists(dbContext);
        }

        private static void seedSurveyIfNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.Surveys.Any())
            {
                var surveyItems = new List<Survey>()
                {
                    new(){Name = "Customer satisfaction survey", Description="Use this template to learn how to keep your customers happy and turn them into advocates for your business.", SurveyStatusId = 1, SurveyTypeId = 2, ImageUrl = "https://prod.smassets.net/assets/content/sm/survey-template-featured-gray-square.webp"},
                    new(){Name = "Customer service survey", Description="Use our customer service survey template to get the feedback you need to keep customers happy.", SurveyStatusId = 1, SurveyTypeId = 2, ImageUrl = "https://prod.smassets.net/assets/content/sm/customer-service-survey-template.png"},
                    new(){Name = "Website feedback survey", Description="Use this survey to assess the effectiveness of your online presence and deliver a better experience.", SurveyStatusId = 1, SurveyTypeId = 2, ImageUrl = "https://prod.smassets.net/assets/content/sm/Website_surveys.png"},
                    new(){Name = "Net Promoter® Score (NPS) survey", Description="Assess customer satisfaction and your company’s performance over time.", SurveyStatusId = 1, SurveyTypeId = 2, ImageUrl = "https://prod.smassets.net/assets/content/sm/net-promoter-score-survey-template.png"},
                };
                dbContext.Surveys.AddRange(surveyItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedQuestionIfNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.Questions.Any())
            {
                var questionItems = new List<Question>()
                {
                    new(){SurveyId = 1, QuestionText="Geçen yıl maaş artışı aldınız mı?", QuestionTypeId = 1},
                    new(){SurveyId = 1, QuestionText="Hangi şehirleri ziyaret ettiniz?", QuestionTypeId = 2},
                    new(){SurveyId = 1, QuestionText="En sevdiğiniz artist kimdir?", QuestionTypeId = 3},
                    new(){SurveyId = 1, QuestionText="Anket sistemimizi değerlendiriniz", QuestionTypeId = 4},
                };
                dbContext.Questions.AddRange(questionItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedQuestionTypeIfNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.QuestionType.Any())
            {
                var questionItems = new List<QuestionType>()
                {
                    new(){Type = "Tek seçmeli"},
                    new(){Type = "Çoktan seçmeli"},
                    new(){Type = "Tek satırlık düz metin"},
                    new(){Type = "Değerlendirme"},

                };
                dbContext.QuestionType.AddRange(questionItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedQuestionOptionsIfNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.QuestionOptions.Any())
            {
                var questionItems = new List<QuestionOption>()
                {
                    new(){Value = "Evet", QuestionId = 1},
                    new(){Value = "Hayır", QuestionId = 1},
                    new(){Value = "Paris", QuestionId = 2},
                    new(){Value = "Londra", QuestionId = 2},
                    new(){Value = "Hong Kong", QuestionId = 2},
                    new(){Value = "New York", QuestionId = 2},
                    new(){Value = "", QuestionId = 3},
                    new(){Value = "1", QuestionId = 4},
                    new(){Value = "10", QuestionId = 4},
                };
                dbContext.QuestionOptions.AddRange(questionItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedResponseIfNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.Responses.Any())
            {
                var responseItems = new List<Response>()
                {
                    //new(){RespondentId = 1, SurveyId = 1},
                };
                dbContext.Responses.AddRange(responseItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedAnswerIfNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.Answers.Any())
            {
                var answerItems = new List<Answer>()
                {
                    //new(){QuestionId = 1, ResponseId = 1, AnswerText = "Answer Text"},
                };
                dbContext.Answers.AddRange(answerItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedAnswerOptionsNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.AnswerOptions.Any())
            {
                var answerOptionItems = new List<AnswerOption>()
                {
                    //new(){AnswerId = 1, QuestionOptionId = 1},
                };
                dbContext.AnswerOptions.AddRange(answerOptionItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedSurveyStatusNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.SurveyStatuses.Any())
            {
                var surveyStatusItems = new List<SurveyStatus>()
                {
                    new(){Status = "Active"},
                    new(){Status = "Completed"},
                    new(){Status = "Canceled"},
                    new(){Status = "Pending"},
                };
                dbContext.SurveyStatuses.AddRange(surveyStatusItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedSurveyTypeIfNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.SurveyTypes.Any())
            {
                var surveyTypeItems = new List<SurveyType>()
                {
                    new(){Type = "Employees"},
                    new(){Type = "Customers"},
                    new(){Type = "Target Markets"},
                    new(){Type = "Other"},
                };
                dbContext.SurveyTypes.AddRange(surveyTypeItems);
                dbContext.SaveChanges();
            }
        }

        private static void seedRespondentNotExists(SurveyDbContext dbContext)
        {
            if (!dbContext.Respondents.Any())
            {
                var respondentItems = new List<Respondent>()
                {
                    new(){EmailAddress = "samet.tunay12@gmail.com", Name = "Samet"},
                };
                dbContext.Respondents.AddRange(respondentItems);
                dbContext.SaveChanges();
            }
        }
    }
}
