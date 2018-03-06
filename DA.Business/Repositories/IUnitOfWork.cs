using DA.Business.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DA.Business.Repositories
{
    public interface IUnitOfWork
    {
        IUser<UserInfo> Users { get; }
        IAccoun<AccountInfo> Accounts { get; }
        ITransaction<TransactionInfo> Transactions { get; }
        void Save();
    }
}
