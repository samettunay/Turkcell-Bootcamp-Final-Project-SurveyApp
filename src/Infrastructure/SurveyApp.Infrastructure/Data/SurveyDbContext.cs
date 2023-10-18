using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Data
{
    public class SurveyDbContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyStatus> SurveyStatuses { get; set; }
        public DbSet<SurveyType> SurveyTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<QuestionType> QuestionType { get; set; }

        public DbSet<Response> Responses { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                        .HasOne(r=>r.Response)
                        .WithMany(a=>a.Answers)
                        .HasForeignKey(r=>r.ResponseId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AnswerOption>()
                        .HasOne(ao => ao.QuestionOption)
                        .WithMany(qo => qo.AnswerOptions)
                        .HasForeignKey(ao => ao.QuestionOptionId)
                        .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
