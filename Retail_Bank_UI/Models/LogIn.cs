using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Retail_Bank_UI.Models
{
    public enum UserType
    {
        Admin,
        Customer
    }
    public class LogIn
    {
        public int CustomerId { get; set; }
        [Required]
        public UserType LogInType { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
