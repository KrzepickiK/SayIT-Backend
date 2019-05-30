using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Translation
    {
        public int Id { get; set; }
        public string TranslationEN { get; set; }
        public string TranslationPL { get; set; }
        public string MeaningPL { get; set; }
        public string MeaningEN { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<QuizQuestion> QuizQuestion { get; set; }
    }
}
