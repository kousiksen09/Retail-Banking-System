using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionMicroservice.Models
{
    public class Transfer
    {
        [Display(Name  = "Please enter Source Account ID")]
        public int Source_ACC_ID { get; set; }
        [Display(Name = "Please enter Destination Account ID")]
        public int Destination_ACC_ID { get; set; }

        public double Amount { get; set; }
    }
}
