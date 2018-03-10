using BA.Database.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.Database.Сommon.Repositories;

namespace BA.Database.Repositories
{
    public class AccountRepositories: IRepositories<Account>
    {
        private DataContext.DataContext db;
        public AccountRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public IEnumerable<Account> GetList()
        {
            var List = db.Accounts.ToList<Account>();
            return List;
        }

        public Account Get(string UserName)
        {
            var Account = db.Accounts.Where(c => c.User.UserName == UserName).SingleOrDefault();
            return Account;
        }

        public void Add(Account Account)
        {
            db.Accounts.Add(Account);
        }
    }
}
