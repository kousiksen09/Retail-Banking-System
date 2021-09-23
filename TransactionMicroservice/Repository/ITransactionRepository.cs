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
        TransactionStatus Deposit(int AccountId, int amount);
        Account GetDetails(int CustomerId);
        TransactionStatus Withdraw(int AccountId, int amount);
        TransactionStatus Transfer(int Source_Account_Id, int Target_Account_Id, int amount);
    }
}
