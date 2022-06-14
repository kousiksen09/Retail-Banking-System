using CustomerMicroService.Model;
using CustomerMicroService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Models;
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
        [HttpPost]
        [Route("createUser")]
        public IActionResult CreateUser(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                _log4net.Info("No Customer has been returned");
                return BadRequest();
            }
            try
            {
            
                if (customer == null)
                {
                    _log4net.Warn("No Matching result found for the id: " + customer.CustomerId);
                    return NotFound();
                }
                var userDetails = _userCredRepository.CreateUser(customer);
                if(userDetails == null)
                {
                    return new StatusCodeResult(409);
                }
                return Ok(userDetails);
                }
               
            
            catch (Exception e)
            {
                _log4net.Error("Error occurred while calling post method" + e.Message);
                return new StatusCodeResult(500);
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
