//using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TransactionMicroservice.Models;


namespace TransactionMicroservice.Repository
{
    public class StatementRepository : IStatementRepository
    {

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StatementRepository));
        private readonly ITransactionRepository transactionRepository;

        private readonly TransactionContext tbc;
        public StatementRepository(ITransactionRepository it,TransactionContext t)
        {
            transactionRepository = it;
            tbc = t;
        } 
        
        

        public async Task<List<Statement>> GetStatementAsync(int account_id, DateTime fromdate, DateTime todate)
        {
            try
            {
                var acc = await transactionRepository.GetDetailsAsync(account_id);
                
                IEnumerable<TransactionHistory> History = null;



                History = transactionRepository.GetTransactionHistory(acc.CustomerId).Where(e=>e.DateOfTransaction.Date >=fromdate.Date && e.DateOfTransaction.Date <= todate.Date);
                List<Statement> s = new List<Statement>();
                

                foreach (TransactionHistory item in History)
                {
                    
                    s.Add(new Statement()
                    {
                        AccountId = item.AccountId,
                        Narration = item.message,
                        DateOfTransaction = item.DateOfTransaction,
                        Amount = item.TransactionAmount,
                        ClosingBalance = item.destination_balance,
                        RefNo = generateRefNo(item.AccountId, item.DateOfTransaction, item.destination_balance)
                    });

                    tbc.Statements.Add(new Statement()
                    {
                        AccountId = item.AccountId,
                      DateOfTransaction=item.DateOfTransaction,
                        Narration = item.message,
                        Amount = item.TransactionAmount,
                        ClosingBalance = item.destination_balance,
                        RefNo = generateRefNo(item.AccountId, item.DateOfTransaction, item.destination_balance) 
                    });
                    

                }

                return s;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in getting accounts from Account API"+e.StackTrace);
                return null;

            }
        }

        public string generateRefNo(int accid, DateTime dt, double destbalance)
        {
            

           string refid = "Retail_Ref" + accid.ToString() + "_on_" + dt.Date.ToString() + "_bal_" + destbalance.ToString();

            return refid;

        }


    }
}
