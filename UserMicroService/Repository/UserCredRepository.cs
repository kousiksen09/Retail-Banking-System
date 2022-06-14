using CustomerMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.DBContext;
using UserMicroService.Models;

namespace UserMicroService.Repository
{
    public class UserCredRepository : IUserCredRepository
    {
        private readonly UserContext _userContext;
        public UserCredRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public UserCred CreateUser(Customer customer)
        {
            try
            {
                if (customer == null)
                    return null;
                var userCred = new UserCred();

                userCred.UserName = customer.Name.ToString();
                userCred.Password = GeneratePassword(customer);
                userCred.CreatedBy = "Admin";
                userCred.CreatedOn = DateTime.Now;
                userCred.UserType = "Customer";
                userCred.CustomerId = customer.CustomerId;
               _userContext.UserCreds.Add(userCred);
               var userDetails= _userContext.SaveChanges();
                return userCred;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
         }
    

        private string GeneratePassword(Customer customer)
        {
            string pass = "RBS"+customer.Name.Split(' ')[0]+customer.CustomerId.ToString()+"@"+customer.DOB.Day.ToString()+customer.DOB.Month.ToString();
            return pass;
        }
    

        public UserCred GetUserCredById(int userid)
        {
            return _userContext.UserCreds.Find(userid);
        }

        public IEnumerable<UserCred> GetUserCreds()
        {
            return _userContext.UserCreds.ToList();
        }
    }
}
