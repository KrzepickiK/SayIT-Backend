using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Translation :BaseEntity
    {
        public int Id { get; set; }
        public string TranslationEN { get; set; }
        public string TranslationPL { get; set; }
        public string MeaningPL { get; set; }
        public string MeaningEN { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<QuizQuestion> QuizQuestion { get; set; }
    }
}
