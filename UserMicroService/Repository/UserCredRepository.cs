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
