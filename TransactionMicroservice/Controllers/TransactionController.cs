using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;
using TransactionMicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransactionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AccountsController));
        private ITransactionRepository _ITR;
        public AccountsController(ITransactionRepository TR)
        {
            _ITR = TR;
        }

        // GET: api/<TransactionController>
        [HttpGet]
        [Route("getTransactions/{CustomerId}")]
        public IActionResult getTransactions(int CustomerId)
        {
            if (CustomerId == 0)
            {
                 _log4net.Info("Invalid Customer Id");
                return NotFound();
            }

            List<TransactionHistory> Ts = _ITR.GetTransactionHistory(CustomerId);
            _log4net.Info("Transaction history returned for Customer Id: " + CustomerId);
            return Ok(Ts);


        }
        [HttpGet]
        [Route("getAccount/{AccountId}")]
        public ActionResult<Account> GetAccount(int AccountId)
        {
            var student = _ITR.GetDetails(AccountId);

            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPut]
        [Route("Deposit/{AccountId},{ammount}")]
        public IActionResult Deposit(int AccountId, int amount)
        {
            if (amount == 0 || AccountId == 0)
            {
                _log4net.Info("Invalid ammount");
                return NotFound();
            }

            TransactionStatus status = _ITR.Deposit(AccountId, amount);
            _log4net.Info("Deposit is Processing for Account: " + AccountId);
            return Ok(status);


        }
        [HttpPut]
        [Route("Withdraw/{AccountId},{ammount}")]
        public IActionResult Withdraw(int AccountId, int ammount)
        {
            if (ammount == 0 || AccountId == 0)
            {
                _log4net.Info("Invalid ammount");
                return NotFound();
            }

            TransactionStatus status = _ITR.Withdraw(AccountId, ammount);
            _log4net.Info("Withdraw is Processingfor Account: " + AccountId);
            return Ok(status);

        }
        [HttpPost]
        [Route("Transfer/{Source_Account_Id},{Target_Account_Id},{amount}")]
        public IActionResult Transfer(int Source_Account_Id, int Target_Account_Id, int amount)
        {
            if (Source_Account_Id == 0 || Target_Account_Id == 0 || amount == 0)
            {
                return NotFound();
            }

            var acc = _ITR.GetDetails(Source_Account_Id);
            if (acc.minBalance > acc.Balance - amount)
            {
                return BadRequest();
            }

            TransactionStatus tr = _ITR.Transfer(Source_Account_Id, Target_Account_Id, amount);
            return Ok(tr);
        }



    }
}
