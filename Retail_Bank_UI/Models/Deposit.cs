using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retail_Bank_UI.Models
{
    public class Deposit
    {
        [Required(ErrorMessage ="Please Enter the Account Id")]
        [Display(Name = "Enter Beneficiary AccountId")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Please Enter the Amount")]
        [Display(Name = "Enter Amount You want to Deposit")]
        public double Amount { get; set; }
    }
}
