using BA.Database.DataContext;
using BA.Database.Modeles;
using BA.Database.Repositories;
using DA.Business.Enteties;
using DA.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private DataContext.DataContext db;
        //private ITransaction<Transaction> TransactionRepository;
        private TransactionRepositories TransactionRepository;
        private IUser<User> UserRepository;
        private IAccoun<Account> AccounRepository;

        public UnitOfWork(DataContext.DataContext _context)
        {
            db = _context;
        }

        public IUser<User> Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepositories(db);
                return UserRepository;
            }
        }

        public IAccoun<Account> Accounts
        {
            get
            {
                if (AccounRepository == null)
                    AccounRepository = new AccountRepositories(db);
                return AccounRepository;
            }
        }

        public TransactionRepositories Transaction
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
