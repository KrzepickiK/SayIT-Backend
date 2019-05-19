using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AvatarUrl { get; set; }
        public int[] AccountTypeId { get; set; }


        public virtual ICollection<AccountType> AccountTypes { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }

    }
}
