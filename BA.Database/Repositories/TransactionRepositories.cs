using DA.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BA.Database.Repositories
{
    public class TransactionRepositories : ITransaction<Transaction>
    {
        private DataContext.DataContext db;
        public TransactionRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public IEnumerable<Transaction> GetListForUser(string UserName)
        {
            //var User = db.Useers.Where(c => c.UserName == UserName).SingleOrDefault();
            //var Transaction = User.Tra.SingleOrDefault();
            //return Account;
            throw new NotImplementedException();
        }

        public Transaction Add(string UserName, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
