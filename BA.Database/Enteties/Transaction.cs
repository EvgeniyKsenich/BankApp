using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Enteties
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Summa { get; set; }
        public int Type { get; set; }

        public virtual Account AccountInfoInitiator { get; set; }
        public virtual Account AccountInfoRecipient { get; set; }
    }
}
