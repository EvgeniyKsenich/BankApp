using BA.Database.Сommon.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Enteties
{
    public class User : IModel
    {
        public User()
        {
            this.Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
