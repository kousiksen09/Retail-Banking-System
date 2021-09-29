
using CustomerMicroService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroService.Models
{
    public class UserCred
    {
        [Key]
        public int UserID { get; set; }
 
        [ForeignKey("Customers")]
        [Required(AllowEmptyStrings = true)]

        public int? CustomerId { get; set; }
      
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customers { get; set; }
    }
}
