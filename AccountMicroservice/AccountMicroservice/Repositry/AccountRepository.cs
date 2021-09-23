using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repositry
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> accounts = new List<Account>()
        {
            //new Account (){AccountId=1, accountType = AccountType.SavingAccount, Balance =5000, MinBalance=1000},
            //new Account (){AccountId=2, accountType = AccountType.CurrentAccount, Balance =1000, MinBalance=500},
        };
       
        public Account GetAccount(int sav_account_id, int curr_account_id)
        {
            var account = accounts.Find(a => a.Sav_AccountId == sav_account_id && a.Cur_AccountId == curr_account_id);
            return account;
        }



        public Account GetPerticularAccount(int accont_id)
        {
            var account = accounts.Find(a => a.Cur_AccountId == accont_id || a.Sav_AccountId == accont_id);
            return account;
        }

        public List<Account> GetCutomerAccounts(int customer_id)
        {

            List<Account> accounts = new List<Account>() { };
            var acc = GetAllAccounts();
            var sav_acc = acc.Find(a => a.CustomerId == customer_id && a.accountType == AccountType.SavingAccount.ToString());
            var cur_acc = acc.Find(a => a.CustomerId == customer_id && a.accountType == AccountType.CurrentAccount.ToString());
            accounts.Add(sav_acc);
            accounts.Add(cur_acc);
            return accounts;
            
        }
        public List<Account> GetAllAccounts()
        {
            return accounts;
        }


        public Account CreateAccount(int customer_id)
        {
            System.Random random = new System.Random();
            accounts.Add(new Account() {Sav_AccountId =random.Next(10,30), CustomerId = customer_id, accountType = AccountType.SavingAccount.ToString(), Balance=5000, MinBalance =100});
            accounts.Add(new Account() {Cur_AccountId =random.Next(40,60), CustomerId = customer_id, accountType = AccountType.CurrentAccount.ToString(), Balance=3000, MinBalance =1000});

            var acc = accounts.Find(a => a.CustomerId == customer_id);
            return acc;
        }


    }
}
