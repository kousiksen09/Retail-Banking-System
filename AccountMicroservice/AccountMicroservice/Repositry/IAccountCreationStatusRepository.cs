using AccountMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Repositry
{
    public interface IAccountCreationStatusRepository
    {
        


        public List<AccountCreationStatus> GetAllCreationStatus();

        public AccountCreationStatus GetCreationStatus(int cur_accountid, int sav_accountid);


    }
}
