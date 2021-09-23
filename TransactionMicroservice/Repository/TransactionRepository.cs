using Microsoft.EntityFrameworkCore;
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
        //   static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(TransactionRepository));

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
            return THistory;
        }

        public TransactionStatus Deposit(int AccountId, int amount)
        {

            var customer = _context.Accounts.Find(AccountId);
            customer.Balance = customer.Balance + amount;
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            TransactionStatus ts = new TransactionStatus { message = "The Money has been Credited Sucessfully and Total Balance is {customer.Balance}" };
            TransactionHistory th = new TransactionHistory
            {
                AccountId = AccountId,
                TransactionAmount = amount,
                destination_balance = 0,
                source_balance = customer.Balance,
                DateOfTransaction = DateTime.Now,
                message = $"₹{amount} Amount Credited",
                CustomerId = customer.CustomerId

            };
            _context.TransactionHistories.Add(th);
            _context.SaveChanges();
            return ts;
        }
        public TransactionStatus Withdraw(int AccountId, int amount)
        {

            var customer = _context.Accounts.Find(AccountId);
            if (customer.Balance - amount < customer.minBalance)
            {
                TransactionStatus ts = new TransactionStatus { message = "The Money withdrawn process is declined" };
                _context.TransactionStatus.Add(ts);
                _context.SaveChanges();
                return ts;
            }
            else
            {
                customer.Balance = customer.Balance - amount;
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();
                TransactionStatus ts = new TransactionStatus { message = "The Money Withdrawl is Sucessful" };
                _context.TransactionStatus.Add(ts);
                TransactionHistory th = new TransactionHistory
                {
                    AccountId = AccountId,
                    TransactionAmount = amount,
                    destination_balance = 0,
                    source_balance = customer.Balance,
                    DateOfTransaction = DateTime.Now,
                    message = $"₹{amount} Amount Debited",
                    CustomerId = customer.CustomerId

                };
                _context.TransactionHistories.Add(th);
                _context.SaveChanges();
                return ts;
            }
        }
        public Account GetDetails(int AccountId)
        {
            Account customer = _context.Accounts.Find(AccountId);
            return customer;
        }
        public TransactionStatus Transfer(int Source_Account_Id, int Target_Account_Id, int amount)
        {
            Withdraw(Source_Account_Id, amount);
            Deposit(Target_Account_Id, amount);
            var cusDebit = GetDetails(Source_Account_Id);
            var cusCredit = GetDetails(Target_Account_Id);
            TransactionStatus tr = new TransactionStatus
            {
                message = "Transction Completed"
            };
            _context.TransactionStatus.Add(tr);
            TransactionHistory th = new TransactionHistory
            {
                AccountId = Source_Account_Id,
                TransactionAmount = amount,
                destination_balance = cusCredit.Balance,
                source_balance = cusDebit.Balance,
                DateOfTransaction = DateTime.Now,
                message = "Transaction done",
                CustomerId = cusDebit.CustomerId

            };
            _context.TransactionHistories.Add(th);
            _context.SaveChanges();


            return tr;

        }
    }
}

