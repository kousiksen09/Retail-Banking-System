using AccountMicroservice.Model;
using AccountMicroservice.Repositry;
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

        public TransactionContext _context;
        public AccountRepository _account;
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
                _log4net.Info("No Record Found for this Customer Id: " + CustomerId);
            }
            return THistory;
        }



        public async Task<TransactionStatus> DepositAsync(int AccountId, double amount)
        {
            TransactionStatus trans = new TransactionStatus();

            try
            {

                Account acc = await GetDetailsAsync(AccountId);
                acc.Balance = acc.Balance + amount;
                // double bal = acc.Balance;
                Account paramAccount = new Account
                {
                    accountType = acc.accountType,
                    Balance = acc.Balance,
                    Cur_AccountId = acc.Cur_AccountId,
                    Sav_AccountId = acc.Sav_AccountId,
                    MinBalance = acc.MinBalance,
                    CustomerId = acc.CustomerId,
                };

                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:5001/api/Account/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    // var postData = new { AccountId = 10000000, amount = 1000 };
                    // var jsonString = JsonConvert.SerializeObject(postData);
                    // var obj = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsJsonAsync("updateAccount/" + AccountId, paramAccount).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        trans.source_balance = acc.Balance - amount;
                        trans.destination_balance = acc.Balance;
                        trans.Message = $"₹ {amount} has been credited successfully.";
                        TransactionHistory th = new TransactionHistory
                        {
                            AccountId = AccountId,
                            TransactionAmount = amount,
                            destination_balance = acc.Balance,
                            source_balance = acc.Balance-amount,
                            DateOfTransaction = DateTime.Now,
                            message = $"₹{amount} Amount Credited to account {AccountId}",
                            CustomerId = acc.CustomerId
                        };
                        _context.TransactionHistories.Add(th);
                        _context.SaveChanges();

                        _log4net.Info("Account details is successfully fetched in rules microservice for AccountId- " + AccountId);
                        return trans;
                        
                    }
                    else
                    {
                        trans.Message = $"₹ {amount} Can't be credited";

                        return trans;
                    }
                }
            }
            catch (Exception) 
            { 
                return null; 
            }
        }



        public async Task<TransactionStatus> WithdrawAsync(int AccountId, double amount)
        {

            TransactionStatus trans = new TransactionStatus();

            try
            {

                Account acc = await GetDetailsAsync(AccountId);
                if (acc.MinBalance < acc.Balance - amount)
                {
                    acc.Balance = acc.Balance - amount;

                    double bal = acc.Balance;
                    Account paramAccount = new Account
                    {
                        accountType = acc.accountType,
                        Balance = acc.Balance,
                        Cur_AccountId = acc.Cur_AccountId,
                        Sav_AccountId = acc.Sav_AccountId,
                        MinBalance = acc.MinBalance,
                        CustomerId = acc.CustomerId,
                    };


                    using (HttpClient client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("https://localhost:5001/api/Account/");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        // var postData = new { AccountId = 10000000, amount = 1000 };
                        // var jsonString = JsonConvert.SerializeObject(postData);
                        // var obj = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage response1 = client.PutAsJsonAsync("updateAccount/" + AccountId, paramAccount).Result;

                        if (response1.IsSuccessStatusCode)
                        {
                            trans.source_balance = acc.Balance + amount;
                            trans.destination_balance = acc.Balance;
                            trans.Message = $"₹ {amount} has been debited.";
                            TransactionHistory th = new TransactionHistory
                            {
                                AccountId = AccountId,
                                TransactionAmount = amount,
                                destination_balance = acc.Balance,
                                source_balance = acc.Balance+amount,
                                DateOfTransaction = DateTime.Now,
                                message = $"₹ {amount} Amount debited from account {AccountId}",
                                CustomerId = acc.CustomerId
                            };
                            _context.TransactionHistories.Add(th);
                            _context.SaveChanges();
                            return trans;
                        }
                        else
                        {
                            trans.Message = $"₹{amount} Can't be Withdrawl";
                            trans.source_balance = 0;
                            trans.destination_balance = 0;


                            return trans;
                        }
                    }
                }
                else
                {
                    trans.Message = "You Dont have enough balance";
                    trans.source_balance = 0;
                    trans.destination_balance = 0;


                    return trans;
                }

            }

            catch (Exception) 
            { 
                return null; 
            }
        }


        public async Task<Account> GetDetailsAsync(int AccountId)
        {

            Account acc = new Account();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:5001/api/Account/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("getAccount/" + AccountId);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        acc = JsonConvert.DeserializeObject<Account>(result);
                        _log4net.Info("Account details is successfully fetched in rules microservice for AccountId- " + AccountId);
                    }
                }
                return acc;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TransactionStatus> TransferAsync(int Source_Account_Id, int Target_Account_Id, double amount)
        {
            TransactionStatus trans = new TransactionStatus();
            //RuleStatus rule = new RuleStatus();

            try
            {
                var cusDebit = await GetDetailsAsync(Source_Account_Id);
                var cusCredit = await GetDetailsAsync(Target_Account_Id);
                if (cusDebit.MinBalance <= cusDebit.Balance - amount)
                {
                    await WithdrawAsync(Source_Account_Id, amount);
                    await DepositAsync(Target_Account_Id, amount);

                    trans.Message = $"₹ {amount} has been transferred from Account Id: {Source_Account_Id} to Account Id: {Target_Account_Id}";
                    trans.source_balance = cusDebit.Balance;
                    trans.destination_balance = cusCredit.Balance;
                    TransactionHistory th = new TransactionHistory
                    {
                        AccountId = Source_Account_Id,
                        TransactionAmount = amount,
                        destination_balance = cusCredit.Balance,
                        source_balance = cusDebit.Balance,
                        DateOfTransaction = DateTime.Now,
                        message = $"₹ {amount} has been transferred from Account Id: {Source_Account_Id} to Account Id: {Target_Account_Id}",
                        CustomerId = cusDebit.CustomerId
                    };
                    _context.TransactionHistories.Add(th);
                    _context.SaveChanges();
                    return trans;
                }

                else
                {
                    trans.Message = "Transfer Failed";
                    trans.source_balance = 0;
                    trans.destination_balance = 0;
                    return trans;
                }
            }
            catch (Exception e)
            {
                trans.Message = e.Message;
                return trans;
            }

        }


    }
}

