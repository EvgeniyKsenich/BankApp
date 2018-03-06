using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DA.Business.Enteties;

namespace BA.Database
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<DA.Business.Enteties.UserInfo> UserInfo { get; set; }
    }
}
