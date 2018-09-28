using DomainLayer.SeedWork;
using DomainLayer.SurveyAggregate.QuestionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate
{
    public abstract class SurveyQuestion : Entity
    {
        public string QuestionText { get; set; }

        public QuestionType QuestionType { get; private set; }

        public SurveyQuestion(string questionText, QuestionType questionType)
        {
            QuestionText = questionText;
            QuestionType = questionType;
        }
    }
}
