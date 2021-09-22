using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCredRepository _userCredRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UserController));
        public UserController(IUserCredRepository userCredRepository)
        {
            _userCredRepository = userCredRepository;
        }
        // GET: api/<UserController>
      
        [HttpGet]
        [Route("getAllUser")]
        public IActionResult GetAllUser()
        {
            try
            {
                _log4net.Info("getAllUser API is initiated");
                var user = _userCredRepository.GetUserCreds();
                return new OkObjectResult(user);
            }
            catch(Exception e)
            {
                _log4net.Error(e.Message);
                throw;

            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Route("getUser/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userCredRepository.GetUserCredById(id);
            return new OkObjectResult(user);
        }

      
    }
}
