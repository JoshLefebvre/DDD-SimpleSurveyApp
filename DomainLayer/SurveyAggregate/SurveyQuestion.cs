using DomainLayer.SeedWork;
using DomainLayer.SurveyAggregate.QuestionTypes;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate
{
    [BsonKnownTypes(typeof(MultipleChoiceQuestion), typeof(TextQuestion), typeof(ScaleQuestion))]
    public abstract class SurveyQuestion : Entity
    {
        /*[BsonId]
        public int QuestionId { get; set; }*/

        public string QuestionText { get; set; }

        public QuestionType QuestionType { get; set; }

        protected SurveyQuestion(){}//Needed for EFCore

        public SurveyQuestion(string questionText, QuestionType questionType)
        {
            QuestionText = questionText;
            QuestionType = questionType;
        }
    }
}
