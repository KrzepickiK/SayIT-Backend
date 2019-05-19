using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
