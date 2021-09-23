using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repositry
{
    public interface IAccountRepository
    {
        public List<Account> GetAllAccounts();

        public Account GetAccount(int sav_account_id, int curr_account_id);
        public Account GetPerticularAccount(int accont_id);

        public Account CreateAccount(int customer_id);

        public List<Account> GetCutomerAccounts(int customer_id);
    }
}
