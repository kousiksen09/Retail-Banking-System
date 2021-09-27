//using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice;
using TransactionMicroservice.Models;
using TransactionMicroservice.Repository;

namespace TransactionMicroservice.Repository
{
    public class StatementRepository : IStatementRepository
    {

        List<Statement> statements = new List<Statement>() { };                     //statement

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



                History = transactionRepository.GetTransactionHistory(acc.CustomerId);
                List<Statement> s = new List<Statement>();
                //Statement st = new Statement();

                foreach (TransactionHistory item in History)
                {
                    
                    s.Add(new Statement()
                    {
                        AccountId = item.AccountId,
                        Narration = item.message,
                        Amount = item.TransactionAmount,
                        ClosingBalance = item.destination_balance,
                        RefNo = generateRefNo(item.AccountId, item.DateOfTransaction, item.destination_balance)
                    });

                    tbc.Statements.Add(new Statement()
                    {
                        AccountId = item.AccountId,
                      
                        Narration = item.message,
                        Amount = item.TransactionAmount,
                        ClosingBalance = item.destination_balance,
                        RefNo = generateRefNo(item.AccountId, item.DateOfTransaction, item.destination_balance) 
                    });
                    

                }

                return s;
            }
            catch (Exception)
            {
                //_log4net.Error("Exception in getting accounts from Account API");
                throw;

            }
        }

        public string generateRefNo(int accid, DateTime dt, double destbalance)
        {
            string refid = null;

            refid = "Retail_Ref" + accid.ToString() + "_on_" + dt.Date.ToString() + "_bal_" + destbalance.ToString();

            return refid;

        }


    }
}
