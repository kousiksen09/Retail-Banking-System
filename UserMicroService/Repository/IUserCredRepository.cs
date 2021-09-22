using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Models;

namespace UserMicroService.Repository
{
   public interface IUserCredRepository
    {
        IEnumerable<UserCred> GetUserCreds();
        UserCred GetUserCredById(int userid);
    }
}
