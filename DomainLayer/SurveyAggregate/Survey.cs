using DomainLayer.SeedWork;
using DomainLayer.SurveyAggregate;
using DomainLayer.SurveyAggregate.QuestionTypes;
using System.Collections.Generic;

namespace DomainLayer.Entities
{
    public class Survey : Entity
    {
        public string SurveyName { get; private set; }

        // Keeping SurveyQuestions private so that new questions cannot be added from "outside the AggregateRoot"
        // but only through the method AddSurveyQuestion() methods which will often include behaviour.
        private readonly List<SurveyQuestion> _surveyQuestions;
        public IReadOnlyCollection<SurveyQuestion> OrderItems => _surveyQuestions;

        public Survey()
        {
            _surveyQuestions = new List<SurveyQuestion>();
        }

        public Survey(string surveyName):this()
        {
            SurveyName = surveyName;
        }

        public void AddMultipleChoiceQuestion(string questionText, string questionA, string questionB, 
            string questionC, string questionD)
        {
            var mcQuestion = new MultipleChoiceQuestion(questionText,  questionA, questionB, questionC, questionD);
            _surveyQuestions.Add(mcQuestion);
        }

        public void AddTextQuestion(string questionText)
        {
            var textQuestion = new TextQuestion(questionText);
            _surveyQuestions.Add(textQuestion);
        }

        public void AddScaleQuestion(string questionText, int scale)
        {
            var scaleQuestion = new TextQuestion(questionText);
            _surveyQuestions.Add(scaleQuestion);
        }

        public void AddMultiSelectQuestion()
        {
            //var msQuestion = new MultiSelectQuestion(questionText);
            //_surveyQuestions.Add(msQuestion);
        }
    }
}
