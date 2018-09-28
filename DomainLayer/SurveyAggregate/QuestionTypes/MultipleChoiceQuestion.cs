using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate.QuestionTypes
{
    public class MultipleChoiceQuestion : SurveyQuestion
    {
        public string AnswerA { get; private set; }
        public string AnswerB { get; private set; }
        public string AnswerC { get; private set; }
        public string AnswerD { get; private set; }

        public MultipleChoiceQuestion(string questionText, string answerA, string answerB, string answerC, string answerD) 
            : base(questionText, QuestionType.MultipleChoice)
        {
            AnswerA = answerA;
            AnswerB = answerB;
            AnswerC = answerC;
            AnswerD = answerD;
        }
    }
}
