﻿using SurveyApp.Entities;
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
                    new(){Name = "Örnek Anketler", Description="Çeşitli soru tipleri için örnekler", SurveyStatusId = 1}
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
                    new(){SurveyId = 1, QuestionText="Geçen yıl maaş artışı aldınız mı?", QuestionTypeId = 1}
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
                    new(){RespondentId = 1, SurveyId = 1},
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
                    new(){QuestionId = 1, ResponseId = 1, AnswerText = "Answer Text"},
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
                    new(){AnswerId = 1, QuestionOptionId = 1},
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
                    new(){Status = "Aktif"},
                };
                dbContext.SurveyStatuses.AddRange(surveyStatusItems);
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