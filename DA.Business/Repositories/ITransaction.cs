using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA.Business.Repositories
{
    public interface ITransaction<T> where T : class
    {
        IEnumerable<T> GetListForUser(string UserName);

        T Add(string UserName, T transaction);
    }
}
