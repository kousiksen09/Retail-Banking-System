using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Model
{
    public class AccountCreationStatus
    {
        public string Message { get; set; }

       /* [ForeignKey("Account")]
        public int SavingsAccountId { get; set; }
        public int CurrentAccountId { get; set; }
*/
        //public Account Accounts { get; set; }
    }
}
