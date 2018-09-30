using System.Collections.Generic;

namespace SimpleCustomerSurveyApp.DataTransferObjects
{
    public class SurveyAnswersDTO
    {
        public string surveyId { get; set; }
        public List<Answers> questions {get; set;}
    }

    public class Answers
    {
        public string questionId { get; set; }
        public string answer { get; set; }
    }
}