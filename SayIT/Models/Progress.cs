using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Progress :BaseEntity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int LearningTypeId { get; set; }
        public int PercentageProgress { get; set; }
 
        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual LearningType LearningType { get; set; }
    }
}
