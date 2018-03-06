using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA.Business.Repositories
{
    public interface IAccoun<T> where T : class
    {
        IEnumerable<T> GetList();

        T GetAccount(string UserName);

        void Add(T Account, string UserName);
    }
}
