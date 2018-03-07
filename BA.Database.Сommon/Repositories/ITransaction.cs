using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Сommon.Repositories
{
    public interface ITransaction<T> where T : class
    {
        IEnumerable<T> GetListForUser(string UserName);

        void Add(T transaction);
    }
}
