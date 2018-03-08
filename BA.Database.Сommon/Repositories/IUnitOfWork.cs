using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Сommon.Repositories
{
    public interface IUnitOfWork<U, A, T> : IDisposable 
        where U:class
        where A: class
        where T: class
    {
        IRepositories<U> Users { get; }
        IRepositories<A> Accounts { get; }
        IRepositories<T> Transaction { get; }
        void Save();
    }
}
