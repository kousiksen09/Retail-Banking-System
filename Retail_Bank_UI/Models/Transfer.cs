using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retail_Bank_UI.Models
{
    public class Transfer
    {
        [Required(ErrorMessage = "Please Enter the Account Id")]
        [Display(Name = "Enter Your AccountId")]
        public int Source_Account_Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Account Id")]
        [Display(Name = "Enter Beneficiary AccountId")]
        public int Target_Account_Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Amount")]
        [Display(Name = "Enter Amount You want to Transfer")]
        public double amount { get; set; }
    }
}
