using BA.Database.Enteties;
using BA.Database.Сommon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BA.Database.Repositories
{
    public class TransactionRepositories : ITransactionRepositories<Enteties.Transaction>
    {
        private DataContext.DataContext db;
        public TransactionRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public IEnumerable<Enteties.Transaction> GetList(string Username)
        {
            //var query = from c in db.Useers
            //            join k in db.Accounts
            //            on c.UserName equals Username
            //            join ossss in db.Transactions on 
            //            select new Enteties.Transaction
            //            {
            //                Id = o.Id,
            //                Summa = o.Summa,
            //                Date = o.Date,
            //                AccountInitiator = o.AccountInitiator,
            //                AccountRecipient = o.AccountRecipient,
            //                Type = o.Type
            //            };
            //return query.ToList();
            throw new NotImplementedException();
        }

        public Enteties.Transaction Get(string Username)
        {
            var ListTransactions = db.Transactions.ToList().OrderBy(x=> x.Date).FirstOrDefault();
            return ListTransactions;
        }

        public IEnumerable<Enteties.Transaction> GetList()
        {
            var ListTransactions = db.Transactions.ToList();
            return ListTransactions;
        }

        public void Add(Enteties.Transaction transaction)
        {
            db.Transactions.Add(transaction);
        }
    }
}
