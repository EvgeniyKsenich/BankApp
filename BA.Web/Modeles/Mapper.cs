using AutoMapper;
using BA.Database.Modeles;
using DA.Business.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Web.Modeles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserInfo>();
            CreateMap<Account, AccountInfo>();
            CreateMap<Transaction, TransactionInfo>();
        }
    }
}
