using BA.Database.DataContext;
using BA.Database.Enteties;
using BA.Database.Repositories;
using DA.Business.Modeles;
using BA.Database.Сommon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork<User, Account, Transaction>
    {
        private DataContext.DataContext db;
        private ITransactionRepositories<Transaction> TransactionRepository;
        private IRepositories<User> UserRepository;
        private IRepositories<Account> AccounRepository;

        public UnitOfWork(DataContext.DataContext _context)
        {
            db = _context;
        }

        public IRepositories<User> Users
        {
            get
            {
                if (UserRepository == null)
                    UserRepository = new UserRepositories(db);
                return UserRepository;
            }
        }

        public IRepositories<Account> Accounts
        {
            get
            {
                if (AccounRepository == null)
                    AccounRepository = new AccountRepositories(db);
                return AccounRepository;
            }
        }

        public ITransactionRepositories<Transaction> Transaction
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
