using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Progress
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int LearningTypeId { get; set; }
        public int PercentageProgress { get; set; }
 
        public User User { get; set; }
        public Category Category { get; set; }
        public LearningType LearningType { get; set; }
    }
}
