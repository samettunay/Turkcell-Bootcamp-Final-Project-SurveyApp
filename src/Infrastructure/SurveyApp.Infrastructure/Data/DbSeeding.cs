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
                    new(){SurveyId = 1, QuestionText="How likely is it that you would recommend this company to a friend or colleague?", QuestionTypeId = 4},
                    new(){SurveyId = 1, QuestionText="Overall, how satisfied or dissatisfied are you with our company?", QuestionTypeId = 1},
                    new(){SurveyId = 1, QuestionText="Which of the following words would you use to describe our products? Select all that apply.", QuestionTypeId = 2},
                    new(){SurveyId = 1, QuestionText="How well do our products meet your needs?", QuestionTypeId = 1},
                    new(){SurveyId = 1, QuestionText="Do you have any other comments, questions, or concerns?", QuestionTypeId = 3},

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
                    new(){Value = "1", QuestionId = 1},
                    new(){Value = "2", QuestionId = 1},
                    new(){Value = "3", QuestionId = 1},
                    new(){Value = "4", QuestionId = 1},
                    new(){Value = "5", QuestionId = 1},
                    new(){Value = "6", QuestionId = 1},
                    new(){Value = "7", QuestionId = 1},
                    new(){Value = "8", QuestionId = 1},
                    new(){Value = "9", QuestionId = 1},
                    new(){Value = "10", QuestionId = 1},


                    new(){Value = "Very satisfied", QuestionId = 2},
                    new(){Value = "Somewhat dissatisfied", QuestionId = 2},
                    new(){Value = "Somewhat satisfied", QuestionId = 2},
                    new(){Value = "Very dissatisfied", QuestionId = 2},
                    new(){Value = "Neither satisfied nor dissatisfied", QuestionId = 2},

                    new(){Value = "Reliable", QuestionId = 3},
                    new(){Value = "High quality", QuestionId = 3},
                    new(){Value = "Useful", QuestionId = 3},
                    new(){Value = "Unique", QuestionId = 3},
                    new(){Value = "Good value for money", QuestionId = 3},
                    new(){Value = "Overpriced", QuestionId = 3},
                    new(){Value = "Impractical", QuestionId = 3},
                    new(){Value = "Ineffective", QuestionId = 3},
                    new(){Value = "Poor quality", QuestionId = 3},
                    new(){Value = "Unreliable", QuestionId = 3},

                    new(){Value = "Extremely well", QuestionId = 4},
                    new(){Value = "Very well", QuestionId = 4},
                    new(){Value = "Somewhat well", QuestionId = 4},
                    new(){Value = "Not so well", QuestionId = 4},
                    new(){Value = "Not at all well", QuestionId = 4},


                    new(){Value = "", QuestionId = 5},
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
