using BA.Database.Modeles;
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

        public DbSet<User> Useers { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
