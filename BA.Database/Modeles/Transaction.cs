using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Modeles
{
    public class Transaction
    {
        public int Id { get; set; }
        public Nullable<int> AccountInitiator { get; set; }
        public int AccountRecipient { get; set; }
        public DateTime Date { get; set; }
        public double Summa { get; set; }
        public int Type { get; set; }

        public virtual Account AccountInfo { get; set; }
        public virtual Account AccountInfo1 { get; set; }
    }
}
