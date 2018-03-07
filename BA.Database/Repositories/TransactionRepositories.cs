using BA.Database.Enteties;
using BA.Database.Сommon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BA.Database.Repositories
{
    public class TransactionRepositories : IRepositories<Enteties.Transaction>
    {
        private DataContext.DataContext db;
        public TransactionRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public Enteties.Transaction Get(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enteties.Transaction> GetList()
        {
            throw new NotImplementedException();
        }

        public void Add(Enteties.Transaction transaction)
        {
            db.Transactions.Add(transaction);
        }
    }
}
