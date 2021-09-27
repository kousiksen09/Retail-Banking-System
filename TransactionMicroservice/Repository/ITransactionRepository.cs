using AccountMicroservice.Model;
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
        Task<TransactionStatus> DepositAsync(int AccountId, double amount);
        Task<Account> GetDetailsAsync(int CustomerId);
        Task<TransactionStatus> WithdrawAsync(int AccountId, double amount);
        Task<TransactionStatus> TransferAsync(int Source_Account_Id, int Target_Account_Id, double amount);
    }
}
