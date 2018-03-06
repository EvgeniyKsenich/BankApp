
using DA.Business.Enteties;
using DA.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Repositories
{
    public class TransactionRepositories: ITransaction<TransactionInfo>
    {
        private DataContext.DataContext db;
        public TransactionRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public IEnumerable<TransactionInfo> GetListForUser(string UserName)
        {
            throw new NotImplementedException();
        }

        public TransactionInfo Add(string UserName, TransactionInfo transaction)
        {
            throw new NotImplementedException();
        }
    }   
}
