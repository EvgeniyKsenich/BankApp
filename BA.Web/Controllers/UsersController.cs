using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.Database.DataContext;
using BA.Database.Enteties;
using BA.Database.UnitOfWork;
using BA.Database.Сommon.Repositories;
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

        [Authorize]
        [HttpPost]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"{User.Identity.Name}");
        }

        [Authorize]
        [HttpPost]
        [Route("getBalance")]
        public IActionResult GetBalance()
        {
            var name = User.Identity.Name;
            var Account = _Unit.Accounts.Get(name);
            return Ok($"{Account.Balance}");
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            var List = _Unit.Users.GetList();
            var UserInfoList = _Mapper.Map<List<UserModel>>(List);
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
        [Route("GetUser")]
        [HttpGet("{UserName}", Name = "GetUser")]
        public UserModel Get(string UserName)
        {
            var User_ = _Unit.Users.Get(UserName);
            if (User_ == null)
                return null;

            var UserModes_ = _Mapper.Map<UserModel>(User_);
            return UserModes_;
        }

    }
}
