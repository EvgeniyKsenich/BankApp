using DA.Business.Enteties;
using DA.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Repositories
{
    public class AccountInfoRepositories: IAccoun<AccountInfo>
    {
        private DataContext.DataContext db;
        public AccountInfoRepositories(DataContext.DataContext _context)
        {
            db = _context;
        }

        public AccountInfo GetAccount(string UserName)
        {
            throw new NotImplementedException();
        }

        public void Add(AccountInfo User)
        {
            throw new NotImplementedException();
        }
    }
}
