using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.SurveyAggregate.QuestionTypes
{
    public class ScaleQuestion : SurveyQuestion
    {
        public int Scale { get; private set; }

        public ScaleQuestion(string questionText, int scale): base(questionText, QuestionType.Scale)
        {
            if (scale > 100 || scale < 0)
                throw new Exception("Scale must be between 0 and 100");
            Scale = scale;
        }
    }
}
