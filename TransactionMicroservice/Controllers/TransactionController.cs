using AccountMicroservice.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

using TransactionMicroservice.Models;
using TransactionMicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransactionMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(TransactionController));
        private ITransactionRepository _ITR;
        public TransactionController(ITransactionRepository TR)
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

        [HttpPost("{AccountId}/{amount}")]
        [Route("Deposit/{AccountId}/{amount}")]
        public async Task<IActionResult> Deposit(int AccountId, double amount)
        {
            if (amount == 0 || AccountId == 0)
            {
                _log4net.Info("Invalid amount");
                return NotFound();
            }

            AccountMicroservice.Model.TransactionStatus status = await _ITR.DepositAsync(AccountId, amount);
            _log4net.Info("Deposit is Processing for Account: " + AccountId);
            return Ok(status);


        }
        [HttpPost("{AccountId}/{amount}")]
        [Route("Withdraw/{AccountId}/{amount}")]
        public async Task<IActionResult> WithdrawAsync(int AccountId, double amount)
        {
            if (amount == 0 || AccountId == 0)
            {
                _log4net.Info("Invalid ammount");
                return NotFound();
            }

            AccountMicroservice.Model.TransactionStatus status = await _ITR.WithdrawAsync(AccountId, amount);
            _log4net.Info("Withdraw is Processingfor Account: " + AccountId);
            return Ok(status);

        }
        [HttpPost("{Source_Account_Id}/{Target_Account_Id}/{ amount}")]
        [Route("Transfer/{Source_Account_Id}/{Target_Account_Id}/{amount}")]
        public async Task<IActionResult> TransferAsync(int Source_Account_Id, int Target_Account_Id, double amount)
        {
            if (Source_Account_Id == 0 || Target_Account_Id == 0 || amount == 0)
            {
                return NotFound();
            }
            AccountMicroservice.Model.TransactionStatus tr = await _ITR.TransferAsync(Source_Account_Id, Target_Account_Id, amount);
            return Ok(tr);
        }



    }
}
