using System;
using System.Collections.Generic;
using BA.Business.ViewModel;
using DA.Business.Modeles;
using DA.Business.Repositories;
using DA.Business.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private static IUserServises UserServises_;

        public UsersController(IUserServises UserServises)
        {
            UserServises_ = UserServises;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<UserView> Get()
        {
            var Users = UserServises_.GetSafeList(User.Identity.Name);
            return Users;
        }

        [HttpPost]
        [Route("register")]
        public bool Post([FromBody]UserModel User_)
        {
            return UserServises_.Register(User_);
        }

        [Authorize]
        [Route("GetCurrentUser")]
        public UserView GetCurrentUser()
        {
            return UserServises_.GetUserViewModel(User.Identity.Name);
        }

        [Authorize]
        [Route("Transactions")]
        public IEnumerable<TransactionView> GetTransactionList()
        {
            var Name = User.Identity.Name;
            return UserServises_.GetTransactionList(Name);
        }

    }
}
