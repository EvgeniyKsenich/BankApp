using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BA.Database.Enteties
{
    public class Transaction
    {
        public Transaction()
        {

        }

        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Summa { get; set; }

        [Required]
        public int Type { get; set; }

        public int AccountInitiatorId { get; set; }
        public Account AccountInitiator { get; set; }

        public int AccountRecipientId { get; set; }
        public Account AccountRecipient { get; set; }
    }
}
