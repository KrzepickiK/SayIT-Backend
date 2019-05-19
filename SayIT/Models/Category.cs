using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string IconUrl { get; set; }

        public virtual ICollection<Translation> Translations { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
    }
}
