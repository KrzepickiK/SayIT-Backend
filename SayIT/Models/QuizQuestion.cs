using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public int TranslationId { get; set; }
        public int LearningTypeId { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }

        public LearningType LearningType { get; set; }
        public Translation Translation { get; set; }
    }
}
