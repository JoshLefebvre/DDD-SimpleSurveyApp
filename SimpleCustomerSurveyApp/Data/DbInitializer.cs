using DomainLayer.Entities;
using InfrastructureLayer.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCustomerSurveyApp.Data
{
    public class DbInitializer
    {
        public DbInitializer()
        {

        }
        public async Task Initialize(SurveyContext context)
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
            context.Add(survey);
            await context.SaveChangesAsync();
        }
    }
}
