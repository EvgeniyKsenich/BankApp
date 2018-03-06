using DA.Business.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Database.DataContext
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<UserInfo> Useers { get; set; }

        public DbSet<AccountInfo> Accounts { get; set; }

        public DbSet<TransactionInfo> Transactions { get; set; }

    }
}
