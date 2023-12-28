using Microsoft.EntityFrameworkCore;

namespace Globomantics.Survey.Models
{
    public class GlobomanticsSurveyDbContext: DbContext
    {
        public GlobomanticsSurveyDbContext(DbContextOptions<GlobomanticsSurveyDbContext> options): base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid surveyId = new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900");
            modelBuilder.Entity<CustomerSurvey>()
                .HasData(
                    new CustomerSurvey(
                        surveyId,
                        "Staff Survey - Carved Rock",
                        "You completed the survey, THANKS!!!"
                    )
                );
            modelBuilder.Entity<SurveyQuestion>()
                .HasData(
                    new SurveyQuestion(surveyId, new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9901"), "How long have you worked at Carved Rock?", "Less than 1 year|1-5 years|More than 5 years"),
                    new SurveyQuestion(surveyId, new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9902"), "Do you enjoy working at Carved Rock?", "Yes|No|Sometimes"),
                    new SurveyQuestion(surveyId, new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9903"), "Any comments on how you find working for Carved Rock?", "")
                );

            Guid customerSurveyResponseId = Guid.NewGuid();

            modelBuilder.Entity<CustomerSurveyResponse>()
                .HasData(
                    new CustomerSurveyResponse(id: customerSurveyResponseId, surveyId: surveyId)
                );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SurveyAnswer>()
                .HasData(
                    new SurveyAnswer(customerSurveyResponseId, "Less than 1 year", "How long have you worked at Carved Rock?"),
                    new SurveyAnswer(customerSurveyResponseId, "Yes", "Do you enjoy working at Carved Rock?"),
                    new SurveyAnswer(customerSurveyResponseId, "It's really cool here!", "Any comments on how you find working for Carved Rock?")
                );

            customerSurveyResponseId = Guid.NewGuid();

            modelBuilder.Entity<CustomerSurveyResponse>()
                .HasData(
                    new CustomerSurveyResponse(id: customerSurveyResponseId, surveyId: surveyId)
                );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SurveyAnswer>()
                .HasData(
                    new SurveyAnswer(customerSurveyResponseId, "More than 5 years", "How long have you worked at Carved Rock?"),
                    new SurveyAnswer(customerSurveyResponseId, "No", "Do you enjoy working at Carved Rock?"),
                    new SurveyAnswer(customerSurveyResponseId, "My computer is really slow", "Any comments on how you find working for Carved Rock?")
                );
        }

        public DbSet<CustomerSurvey> CustomerSurveys { get; set; }

        public DbSet<CustomerSurveyResponse> CustomerSurveyResponses { get; set; }

        public DbSet<SurveyQuestion> CustomerSurveyQuestions { get; set; }
    }
}
