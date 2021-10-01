
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
        private IStatementRepository _ISR;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(TransactionController));
        private ITransactionRepository _ITR;
        public TransactionController(ITransactionRepository TR, IStatementRepository SR)
        {
            _ITR = TR;
            _ISR = SR;

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

        [HttpPost]
        [Route("Deposit")]
        public async Task<IActionResult> Deposit(Deposit _deposit)
        {
            if (_deposit.Amount == 0 || _deposit.AccountId == 0)
            {
                _log4net.Info("Invalid amount");
                return NotFound();
            }

            AccountMicroservice.Model.TransactionStatus status = await _ITR.DepositAsync(_deposit.AccountId, _deposit.Amount);
            _log4net.Info("Deposit is Processing for Account: " + _deposit.AccountId);
            return Ok(status);


        }
        [HttpPost]
        [Route("Withdraw")]
        public async Task<IActionResult> WithdrawAsync(Deposit _deposit)
        {
            if (_deposit.Amount== 0 || _deposit.AccountId == 0)
            {
                _log4net.Info("Invalid ammount");
                return NotFound();
            }

            AccountMicroservice.Model.TransactionStatus status = await _ITR.WithdrawAsync(_deposit.AccountId, _deposit.Amount);
            _log4net.Info("Withdraw is Processingfor Account: " + _deposit.AccountId);
            return Ok(status);

        }
        [HttpPost]
        [Route("Transfer")]
        public async Task<IActionResult> TransferAsync(Transfer _transfer)
        {
            if (_transfer.Source_ACC_ID == 0 || _transfer.Destination_ACC_ID == 0 || _transfer.Amount == 0)
            {
                return NotFound();
            }
            AccountMicroservice.Model.TransactionStatus tr = await _ITR.TransferAsync(_transfer.Source_ACC_ID, _transfer.Destination_ACC_ID, _transfer.Amount);
            return Ok(tr);
        }

        [HttpGet]
        [Route("getStatement/{AccountId}/{Fromdate}/{Todate}")]
        public async Task<IActionResult> getStatementAsync(int AccountId, DateTime Fromdate, DateTime Todate)
        {
            if (AccountId == 0)
            {
                _log4net.Info("Invalid Account Id");
                return NotFound();
            }

            List<Statement> Ts = await _ISR.GetStatementAsync(AccountId, Fromdate, Todate);
            _log4net.Info("Transaction history returned for Account Id: " + AccountId);
            return Ok(Ts);


        }


    }
}
