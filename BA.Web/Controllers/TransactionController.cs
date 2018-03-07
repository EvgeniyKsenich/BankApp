using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BA.Database.Enteties;
using BA.Database.Сommon.Repositories;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [Route("Deposit")]
        public IActionResult GetBalance(int count)
        {
            var name = User.Identity.Name;
            var Account = _Unit.Accounts.Get(name);
            Account.Balance += count;
            //////////////////////////////////
            //                              //
            // Add transaction loging logic //
            //                              //
            //////////////////////////////////
            _Unit.Save();
            return Ok();
        }
    }
}
