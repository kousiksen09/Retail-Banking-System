using AccountMicroservice.Data;
using AccountMicroservice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repositry
{

    public class AccountRepository : IAccountRepository
    {


        private readonly AccountMicroserviceDbContext _context;

        System.Random random = new System.Random();


        public AccountRepository(AccountMicroserviceDbContext context)
        {
            _context = context;

        }



        public bool CreateAccount(int customer_id)
        {
            var acc = GetCutomerAccounts(customer_id);
            bool existingCustomer = false;

            if (acc[0] == null && acc[1] == null)
            {
                existingCustomer = false;
            }
            else
            {
                existingCustomer = true;
            }



            if (existingCustomer == false)
            {
                _context.Accounts.Add(new Account() { Sav_AccountId = GenerateSavingsAccountId() + (customer_id + 1), Cur_AccountId = 0, CustomerId = customer_id, accountType = AccountType.SavingAccount.ToString(), Balance = 5000, MinBalance = 100 });
                _context.Accounts.Add(new Account() { Sav_AccountId = 0, Cur_AccountId = GenerateCurrentAccountId() + (customer_id + 2), CustomerId = customer_id, accountType = AccountType.CurrentAccount.ToString(), Balance = 3000, MinBalance = 1000 });
                _context.SaveChanges();
                return true;
            }



            else
                return false;

        }



        public int GenerateSavingsAccountId()
        {

            return random.Next(100000, 300000);

        }

        public int GenerateCurrentAccountId()
        {
            return random.Next(400000, 600000);

        }



        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
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


        public Account GetParticularAccount(int accont_id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Cur_AccountId == accont_id || a.Sav_AccountId == accont_id);

            return account;

        }


    }

    }