using DomainLayer.Entities;
using DomainLayer.SurveyAggregate;
using DomainLayer.SurveyAggregate.QuestionTypes;
using InfrastructureLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.DBContexts
{
    public class SurveyContext : DbContext
    {
        public SurveyContext(DbContextOptions<SurveyContext> options) : base(options)
        {

        }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<SurveyQuestion> Questions {get; set;}
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions{get; set;}
        public DbSet<ScaleQuestion> ScaleQuestions { get; set; }
        public DbSet<TextQuestion> TextQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //An owned entity type allows you to map types that do not have their own identity explicitely defined in the domain model and are 
            //used as properties, such as a value object, within any of your entities
            //https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects
            modelBuilder.ApplyConfiguration(new MultipleChoiceQuestionTypeConfiguration());

            //Configure table-per-hierarchy inheritance
          /*  modelBuilder.Entity<Survey>().ToTable("Surveys");
            modelBuilder.Entity<SurveyQuestion>().ToTable("SurveyQuestions");
            
            //modelBuilder.Entity<MultipleChoiceQuestion>().ToTable("MultipleChoiceQuestion");
            modelBuilder.Entity<ScaleQuestion>().ToTable("ScaleQuestion");
            modelBuilder.Entity<TextQuestion>().ToTable("TextQuestion");*/

        }
    }
}
