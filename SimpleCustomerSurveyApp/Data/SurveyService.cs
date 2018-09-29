using DomainLayer.Entities;
using DomainLayer.SurveyAggregate;
using InfrastructureLayer.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCustomerSurveyApp.Data
{
    public interface ISurveyService
    {
        Task CreateSurvey();
        Task<Survey> GetSurvey(int id);
    }

    public class SurveyService : ISurveyService
    {
        private readonly ISurveryRepository _surveryRepository;

        public SurveyService(ISurveryRepository surveryRepository)
        {
            _surveryRepository = surveryRepository;
        }

        public async Task CreateSurvey()
        {
            //Create a new Survey
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

            //Persist to database
            await _surveryRepository.SaveAsync(survey);
        }

        public async Task<Survey> GetSurvey(int id)
        {
            return await _surveryRepository.GetAsync(id);
        }
    }
}
