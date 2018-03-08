using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.Database.DataContext;
using BA.Database.Enteties;
using BA.Database.UnitOfWork;
using BA.Database.Сommon.Repositories;
using BA.Web.Modeles;
using DA.Business.Modeles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private IUnitOfWork<User, Account, Transaction> _Unit;
        private IMapper _Mapper;

        public UsersController(IUnitOfWork<User, Account, Transaction> Unit, IMapper mapper)
        {
            _Mapper = mapper;
            _Unit = Unit;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserView> Get()
        {
            var List = _Unit.Users.GetList();
            var UserInfoList = _Mapper.Map<List<UserView>>(List);
            return UserInfoList;
        }

        // POST: api/Users
        [HttpPost]
        [Route("register")]
        public void Post([FromBody]UserModel User_)
        {
            var UserEntetys = _Mapper.Map<User>(User_);
            _Unit.Users.Add(UserEntetys);
            _Unit.Accounts.Add(new Account()
            {
                Balance = 0.0,
                UserInfo = UserEntetys
            });
            _Unit.Save();
        }

        // GET: api/Users/5
        [Authorize]
        [Route("GetCurrentUser")]
        public UserView GetCurrentUser()
        {
            var User_ = _Unit.Users.Get(User.Identity.Name);
            var UserModes_ = _Mapper.Map<UserView>(User_);
            return UserModes_;
        }

    }
}
