using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(TransactionRepository));

        /*static List<TransactionHistory> historyList = new List<TransactionHistory>() {
            new TransactionHistory(){TransactionId=1,AccountId=1,CustomerId=1,
                message="Account has been credited",source_balance=1000,destination_balance=1500,DateOfTransaction=DateTime.Now},
        new TransactionHistory(){TransactionId=2,AccountId=2,CustomerId=2,
                message="Account has been Debited",source_balance=2000,destination_balance=1500,DateOfTransaction=DateTime.Now}
      };*/

        public TransactionContext _context;
        public TransactionRepository(TransactionContext context)
        {
            _context = context;
        }
        List<TransactionHistory> THistory = new List<TransactionHistory>();
        public List<TransactionHistory> GetTransactionHistory(int CustomerId)
        {
            try
            {
                foreach (var list in _context.TransactionHistories)
                {
                    if (list.CustomerId == CustomerId)
                    {
                        THistory.Add(list);
                    }
                }

                if (THistory.Count == 0)
                {
                    throw new System.ArgumentException("No Record Found for this Customer Id: " + CustomerId);
                }

            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);
                throw;
            }
            return THistory;
        }
        
    }
}

