using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Сommon.Repositories
{
    public interface ITransactionRepositories<T> where T : class
    {
        IEnumerable<T> GetList(string UserName);

        void Add(T transaction);
    }
}
