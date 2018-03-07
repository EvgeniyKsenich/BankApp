using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.Database.Enteties;
using BA.Database.Сommon.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private IUnitOfWork<User, Account, Transaction> _Unit;
        private IMapper _Mapper;

        public TransactionController(IUnitOfWork<User, Account, Transaction> Unit, IMapper mapper)
        {
            _Mapper = mapper;
            _Unit = Unit;
        }

        // GET: api/Transaction
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transaction/5
        [HttpGet("{id}", Name = "GetTransaction")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Transaction
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
