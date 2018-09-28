using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate.QuestionTypes
{
    public class TextQuestion : SurveyQuestion
    {
        public TextQuestion(string questionText) : base(questionText, QuestionType.Text)
        {

        }
    }
}
