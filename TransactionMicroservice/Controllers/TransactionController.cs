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

            try
            {
                List<TransactionHistory> Ts = _ITR.GetTransactionHistory(CustomerId);
                _log4net.Info("Transaction history returned for Customer Id: " + CustomerId);
                return Ok(Ts);
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
