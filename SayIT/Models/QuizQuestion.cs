using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuizQuestion : BaseEntity 
    {
        public int Id { get; set; }
        public int TranslationId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }

        public virtual QuizQuestionType QuestionType { get; set; }
        public virtual Translation Translation { get; set; }
    }
}
