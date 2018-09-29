using DomainLayer.SurveyAggregate.QuestionTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.EntityFramework
{
    public class MultipleChoiceQuestionTypeConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> multipleChoiceConfiguration)
        {
            //multipleChoiceConfiguration.ToTable("MultipleChoiceQuestions");
            
            //Value objects
            multipleChoiceConfiguration.OwnsOne(t => t.AnswerA);
            multipleChoiceConfiguration.OwnsOne(t => t.AnswerB);
            multipleChoiceConfiguration.OwnsOne(t => t.AnswerC);
            multipleChoiceConfiguration.OwnsOne(t => t.AnswerD);

        }
    }
}
