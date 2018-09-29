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

        private readonly List<int> _answers;
        public IReadOnlyCollection<int> Answers => _answers;

        public ScaleQuestion(string questionText, int scale): base(questionText, QuestionType.Scale)
        {
            if (scale > 100 || scale < 0)
                throw new Exception("Scale must be between 0 and 100");

            _answers = new List<int>();
            Scale = scale;
        }

        public void AddScaleAnswer(int answer)
        {
            if(answer>Scale || answer<Scale)
                throw new Exception("Scale anser must be within acceptable");

            _answers.Add(answer);
        }
    }
}
