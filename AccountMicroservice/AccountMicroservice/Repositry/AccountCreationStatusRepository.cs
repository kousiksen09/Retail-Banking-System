using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repositry
{
    public class AccountCreationStatusRepository : IAccountCreationStatusRepository
    {

        
        public List<AccountCreationStatus> acc_status = new List<AccountCreationStatus>()
        {
            //new AccountCreationStatus {AccountId = 1, Message ="Created" },
            //new AccountCreationStatus {AccountId = 2, Message ="not Created" },
        };
        
        private readonly IAccountRepository Accounts;
        public AccountCreationStatusRepository(IAccountRepository account)
        {
            Accounts = account;
        }
        
        public List<AccountCreationStatus> GetAllCreationStatus()
        {
            return acc_status;
        }

        public AccountCreationStatus GetCreationStatus(int cur_accountid, int sav_accountid)
        {
            
            var account = Accounts.GetAccount(sav_accountid, cur_accountid);
            if (account != null)
            {
                acc_status.Add(new AccountCreationStatus { SavingsAccountId = sav_accountid, CurrentAccountId = cur_accountid, Message = "Success" });
                return acc_status.Find(a => a.CurrentAccountId == cur_accountid && a.SavingsAccountId == sav_accountid);
            }

            else
            {
                acc_status.Add(new AccountCreationStatus { SavingsAccountId = sav_accountid, CurrentAccountId = cur_accountid, Message = "Fail" });
                return acc_status.Find(a => a.CurrentAccountId == cur_accountid && a.SavingsAccountId == sav_accountid);
            }

        }
    }
}
