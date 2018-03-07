using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.Сommon.Repositories
{
    public interface IAccoun<T> where T : class
    {
        IEnumerable<T> GetList();

        T GetAccount(string UserName);

        void Add(T Account);
    }
}
