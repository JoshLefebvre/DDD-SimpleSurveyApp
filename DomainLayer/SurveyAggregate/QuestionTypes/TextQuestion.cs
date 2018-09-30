using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate.QuestionTypes
{
    public class TextQuestion : SurveyQuestion
    {
        public List<string> _answers { get; set; }
        public IReadOnlyCollection<string> Answers => _answers;
        
        public TextQuestion(string questionText) : base(questionText, QuestionType.Text)
        {
            _answers = new List<string>();
        }

        public override void UpdateAnswer(string answer)
        {
            //This case shouldn't be happening 
            //Need to figure out how to store empty list in mongodb
            if (_answers == null)
                _answers = new List<string>();
            _answers.Add(answer);
        }
    }
}
