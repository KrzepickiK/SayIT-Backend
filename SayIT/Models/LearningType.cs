using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LearningType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Progress> Progresses { get; set; }
    }
}
