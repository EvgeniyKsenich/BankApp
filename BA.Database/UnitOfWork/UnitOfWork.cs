using BA.Database.DataContext;
using BA.Database.Repositories;
using DA.Business.Enteties;
using DA.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DataContext.DataContext db;
        private IUser<UserInfo> UserRepository;
        private IAccoun<AccountInfo> AccounRepository;
        private ITransaction<TransactionInfo> TransactionRepository;

        public UnitOfWork(DataContext.DataContext _context)
        {
            db = _context;
        }

        public IUser<UserInfo> Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserInfoRepositories(db);
                return UserRepository;
            }
        }

        public IAccoun<AccountInfo> Accounts
        {
            get
            {
                if (AccounRepository == null)
                    AccounRepository = new AccountInfoRepositories(db);
                return AccounRepository;
            }
        }

        public ITransaction<TransactionInfo> Transactions
        {
            get
            {
                if (TransactionRepository == null)
                    TransactionRepository = new TransactionRepositories(db);
                return TransactionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }




        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
