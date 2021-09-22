using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace TransactionMicroservice.Repository
{
    public interface ITransactionRepository
    {
        List<TransactionHistory> GetTransactionHistory(int CustomerId);
        //TransactionStatus Deposit(int AccountId, int amount);
        //TransactionStatus Withdraw(int AccountId, int amount);
        //TransactionStatus transfer(int SourceAccountId, int DestinationAccountId, int amount);
    }
}
