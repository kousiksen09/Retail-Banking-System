using CustomerMicroService.Model;
using CustomerMicroService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CustomerController));
        public CustomerController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        [Route("getCustomerDetails/{id}")]
        public IActionResult GetCustomerDetails(int id)
        {
            if(id==0)
            {
                _log4net.Warn("User send some invalid customer id");
                return BadRequest();
            }
            
            try
            {
                Customer listCustomer = new Customer();
                listCustomer = _repositoryWrapper.Customer.FindByCondition(id);
                if (listCustomer == null)
                {
                    _log4net.Warn("No Matching result found for the id: " + id);
                    return NotFound();
                }
                else
                {
                    _log4net.Info("Customer details  has been successfully retrieved");
                    return Ok(listCustomer);
                }
            }
            catch(Exception e)
            {
                _log4net.Error(e.Message);
                return new StatusCodeResult(500);
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        [Route("createCustomer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                _log4net.Info("No Customer has been returned");
                return BadRequest();
            }
            try
            {
                CustomerCreationStatus customerCreationStatus = new CustomerCreationStatus();
                bool isCreated = _repositoryWrapper.Customer.Create(customer);
                _repositoryWrapper.Save();
                if (isCreated)
                {
                    _log4net.Info("Customer has been successfully created");
                    customerCreationStatus.Message = "Created Successfully";
                    customerCreationStatus.CustomerId = customer.CustomerId;
                    return Ok(customerCreationStatus);
                }
                else
                {
                    return new StatusCodeResult(409);
                }
            }
            catch(Exception e)
            {
                _log4net.Error("Error occurred while calling post method" + e.Message);
                return new StatusCodeResult(500);
            }
            
        }

    }
}
