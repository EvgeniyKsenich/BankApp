using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA.Business.Enteties
{
    public class TransactionInfo
    {
        public int Id { get; set; }

        public int AccountInitiator { get; set; }

        public int AccountRecipient { get; set; }

        public DateTime Date { get; set; }

        public double Summa { get; set; }

        public int Type { get; set; }
    }
}
