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
        public IEnumerable<UserModel> Get()
        {
            var List = _Unit.Users.GetList();
            var UserInfoList = _Mapper.Map<List<UserModel>>(List);
            return UserInfoList;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
    }
}
