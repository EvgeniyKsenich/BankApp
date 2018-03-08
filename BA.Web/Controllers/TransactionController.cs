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
        public IActionResult Deposit(int summa)
        {
            var name = User.Identity.Name;
            var Account = _Unit.Accounts.Get(name);
            Account.Balance += summa;
            //////////////////////////////////
            var Trans = new Transaction()
            {
                Date = DateTime.Now,
                Summa = summa,
                Type = 0,
                AccountInfo1 = Account
            };
            _Unit.Transaction.Add(Trans);
            //////////////////////////////////
            _Unit.Save();
            return Ok("Ok");
        }

        [Authorize]
        [Route("Withdraw")]
        public IActionResult Withdraw(int summa)
        {
            var name = User.Identity.Name;
            var Account = _Unit.Accounts.Get(name);
            if(Account.Balance < summa)
                return Ok("Not enough money");

            Account.Balance -= summa;
            //////////////////////////////////
            //                              //
            // Add transaction loging logic //
            //                              //
            //////////////////////////////////
            _Unit.Save();
            return Ok("Ok");
        }

        [Authorize]
        [Route("Transfer")]
        public IActionResult Transfer(int summa, string UserReceiverName)
        {
            var name = User.Identity.Name;
            var Account = _Unit.Accounts.Get(name);
            if (Account.Balance < summa)
                return Ok("Not enough money");

            var UserReceiver = _Unit.Accounts.Get(UserReceiverName);
            if(UserReceiver == null)
                return Ok("404 User receiver not found");

            Account.Balance -= summa;
            UserReceiver.Balance += summa;
            //////////////////////////////////
            //                              //
            // Add transaction loging logic //
            //                              //
            //////////////////////////////////
            _Unit.Save();
            return Ok("Ok");
        }
    }
}
