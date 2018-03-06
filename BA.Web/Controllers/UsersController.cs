using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BA.Database.DataContext;
using BA.Database.UnitOfWork;
using DA.Business.Enteties;
using DA.Business.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private IUnitOfWork _Unit;
        public UsersController(DataContext _context)
        {
            _Unit = new UnitOfWork(_context);
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserInfo> Get()
        {
            _Unit.Users.Add(new UserInfo() {Id = 0, Name ="Name", DateOfBirth = DateTime.Now, Email="mail@mail.com",Password="1111",Surname="Surn",UserName="Usr1" });
            var List = _Unit.Users.GetList();
            return List;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
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
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
