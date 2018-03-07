using AutoMapper;
using BA.Database.Enteties;
using DA.Business.Modeles;
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
            CreateMap<User, UserModel>();
            CreateMap<Account, AccountModel>();
            CreateMap<Transaction, TransactionModel>();
        }
    }
}
