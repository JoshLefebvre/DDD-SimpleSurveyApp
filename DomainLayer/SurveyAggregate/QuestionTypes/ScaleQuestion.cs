using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate.QuestionTypes
{
    public class ScaleQuestion : SurveyQuestion
    {
        public int Scale { get; private set; }

        public List<int> _answers { get; set; }
        public IReadOnlyCollection<int> Answers => _answers;


        public ScaleQuestion(string questionText, int scale)
            : base(questionText, QuestionType.Scale)
        {
            if (scale > 100 || scale < 0)
                throw new Exception("Scale must be between 0 and 100");

            _answers = new List<int>();
            Scale = scale;
        }

        public override void UpdateAnswer(string answer)
        {
            int numAnswer= 0;

            if (!int.TryParse(answer, out numAnswer))
                throw new Exception("Scale answer must be a digit");

            if (numAnswer > Scale || numAnswer < 0)
                throw new Exception("Scale anser must be within acceptable");

            //This case shouldn't be happening 
            //Need to figure out how to store empty list in mongodb
            if (_answers == null)
                _answers = new List<int>();

            _answers.Add(numAnswer);
        }
    }
}
