using DomainLayer.Entities;
using DomainLayer.SurveyAggregate;
using InfrastructureLayer.MongoDB;
using SimpleCustomerSurveyApp.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCustomerSurveyApp.Data
{
    public interface ISurveyService
    {
        Task CreateSurveyAsync();
        Task<Survey> GetSurveyAsync(string id);
        Task SubmitSurveyAsync(SurveyAnswersDTO surveyAnswersDTO);
    }

    public class SurveyService : ISurveyService
    {
        private readonly ISurveryRepository _surveryRepository;

        public SurveyService(ISurveryRepository surveryRepository)
        {
            _surveryRepository = surveryRepository;
        }

        public async Task CreateSurveyAsync()
        {
            //For MVP we are creating a survey with prepoulated questions
            var survey = CreateFakeSurvey();

            await _surveryRepository.CreateAsync(survey);
        }

        public async Task<Survey> GetSurveyAsync(string id)
        {
            return await _surveryRepository.GetAsync(id);
        }

        public async Task SubmitSurveyAsync(SurveyAnswersDTO surveyAnswersDTO)
        {
            var survey = await GetSurveyAsync(surveyAnswersDTO.surveyId);

            foreach(var question in surveyAnswersDTO.questions)
            {
                survey.answerQuestion(question.questionId, question.answer);
            }

            await _surveryRepository.UpdateAsync(survey);
        }


        #region private functions
        private Survey CreateFakeSurvey()
        {
            var survey = new Survey("Customer Satisfaction Survey");

            //Add Questions
            survey.AddScaleQuestion("How likely is it that you would recommend this company to a friend or colleague ?", 10);
            survey.AddMultipleChoiceQuestion(
                "Overall, how satisfied or dissatisfied are you with our company ?",
                "Very Satisfied",
                "Somewhat Satisfied",
                "Somewhat dissatisfied",
                "Very dissatisfied"
            );
            //survey.AddMultiSelectQuestion("Which of the following words would you use to describe our products? Select all that apply.");
            survey.AddMultipleChoiceQuestion(
                "How well do our products meet your needs?",
                "Very Satisfied",
                "Somewhat Satisfied",
                "Somewhat dissatisfied",
                "Very dissatisfied"
            );

            survey.AddTextQuestion("Do you have any other comments, questions, or concerns?");

            return survey;
        }
        #endregion
    }
}
