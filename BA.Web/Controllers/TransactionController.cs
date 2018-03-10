using DA.Business.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BA.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction")]
    public class TransactionController : Controller
    {
        private static ITransactionServisesRepositoryes TransactionServises_;

        public TransactionController(ITransactionServisesRepositoryes TransactionServises)
        {
            TransactionServises_ = TransactionServises;
        }

        [Authorize]
        [Route("Deposit")]
        public IActionResult Deposit(double amount)
        {
            var Username = User.Identity.Name;
            var result = TransactionServises_.Deposit(Username, amount);
            return Ok(result.ToString());
        }

        [Authorize]
        [Route("Withdraw")]
        public IActionResult Withdraw(double amount)
        {
            var Username = User.Identity.Name;
            var result = TransactionServises_.Withdraw(Username, amount);
            return Ok(result.ToString());
        }

        [Authorize]
        [Route("Transfer")]
        public IActionResult Transfer(double amount, string UserReceiverName)
        {
            var Username = User.Identity.Name;
            var result = TransactionServises_.Transfer(amount, Username, UserReceiverName);
            return Ok(result.ToString());
        }
    }
}
