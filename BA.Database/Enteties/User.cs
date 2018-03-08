using BA.Database.Сommon.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Enteties
{
    public class User : IModel
    {
        public User()
        {
            this.AccountInfo = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Account> AccountInfo { get; set; }
    }
}
