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


        public Account GetParticularAccount(int accont_id);

        public bool CreateAccount(int customer_id);

        public List<Account> GetCutomerAccounts(int customer_id);
    }
}
