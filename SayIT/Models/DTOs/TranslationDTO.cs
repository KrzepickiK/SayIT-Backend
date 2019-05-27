using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TranslationDTO
    {
        public string TranslationEN { get; set; }
        public string TranslationPL { get; set; }
        public string MeaningPL { get; set; }
        public string MeaningEN { get; set; }
        public int CategoryId { get; set; }
    }
}
