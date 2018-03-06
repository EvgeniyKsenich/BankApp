using BA.Database.Modeles;
using DA.Business.Enteties;
using DA.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Repositories
{
    public class AccountRepositories: IAccoun<Account>
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

        public Account GetAccount(string UserName)
        {
            var User = db.Useers.Where(c => c.UserName == UserName).SingleOrDefault();
            var Account = User.AccountInfo.SingleOrDefault();
            return Account;
        }

        public void Add(Account Account, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
