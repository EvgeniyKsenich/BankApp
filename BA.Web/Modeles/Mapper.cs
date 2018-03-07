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
            CreateMap<UserModel, User>().ForMember(x => x.AccountInfo, opt => opt.Ignore()); ;
            CreateMap<Account, AccountModel>();
            CreateMap<Transaction, TransactionModel>();
        }
    }
}
