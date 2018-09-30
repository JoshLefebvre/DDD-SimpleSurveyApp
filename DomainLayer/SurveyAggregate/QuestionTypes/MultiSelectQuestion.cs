using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate.QuestionTypes
{
    public class MultiSelectQuestion : SurveyQuestion
    {
        public MultiSelectQuestion(string questionText, string answerA, string answerB, string answerC, string answerD)
            : base(questionText, QuestionType.MultiSelect)
        {
        }

        public override void UpdateAnswer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
