using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.Database.DataContext;
using BA.Database.UnitOfWork;
using DA.Business.Enteties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private UnitOfWork _Unit;
        private IMapper _Mapper;

        public AccountController(DataContext context, IMapper mapper)
        {
            _Mapper = mapper;
            _Unit = new UnitOfWork(context);
        }

        // GET: api/Account
        [HttpGet]
        public IEnumerable<AccountInfo> Get()
        {
            var List = _Unit.Accounts.GetList();
            var AccountInfoList = _Mapper.Map<List<AccountInfo>>(List);
            return AccountInfoList;
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "GetAccount")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Account
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Account/5
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
