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
        private readonly List<string> _answers;
        public IReadOnlyCollection<string> Answers => _answers;
        
        public TextQuestion(string questionText) : base(questionText, QuestionType.Text)
        {
            _answers = new List<string>();
        }

        public void AddAnswer(string answer)
        {
            _answers.Add(answer);
        }

    }
}
