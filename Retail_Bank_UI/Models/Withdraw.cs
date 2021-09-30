using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retail_Bank_UI.Models
{
    public class Withdraw
    {
        [Required(ErrorMessage = "Please Enter the Account Id")]
        [Display(Name = "Enter Your AccountId")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Please Enter the Amount")]
        [Display(Name = "Enter Amount You want to Withdraw")]
        public double Amount { get; set; }
    }
}
