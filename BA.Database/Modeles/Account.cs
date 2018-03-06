using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Modeles
{
    public class Account
    {
        public int Id { get; set; }
        public int UsurId { get; set; }
        public double Balance { get; set; }

        public virtual User UserInfo { get; set; }
    }
}
