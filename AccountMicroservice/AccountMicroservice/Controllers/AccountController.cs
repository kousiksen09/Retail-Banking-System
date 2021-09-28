using AccountMicroservice.Data;
using AccountMicroservice.Model;
using AccountMicroservice.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {



        private readonly IAccountRepository _AccountRepo;

        private readonly AccountMicroserviceDbContext _accountMicroserviceDbContext;

        public AccountController(IAccountRepository AccountRepo)
        {

            _AccountRepo = AccountRepo;
            
           
        }
        public AccountController(AccountMicroserviceDbContext _acm)
        {

            _accountMicroserviceDbContext = _acm;

        }




        [HttpPost("{customer_id}")]
        [Route("createAccount/{customer_id}")]
        public ActionResult<string> CreteAccount(int customer_id)
        {
            AccountCreationStatus creationStatus = new AccountCreationStatus();
            try
            {
                var newaccount = _AccountRepo.CreateAccount(customer_id);



                if (newaccount)
                {
                    creationStatus.Message = "Account Created Successfully!!";
                    return Ok(creationStatus);
                }
                else
                {



                    creationStatus.Message = "Account already exists!!!!";
                    return BadRequest(creationStatus.Message);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }




        [HttpGet]
        [Route("getAllAccounts")]
        public ActionResult<List<Account>> GetAccounts()
        {
            return _AccountRepo.GetAllAccounts();
        }




        [HttpGet]
        [Route("getCustomerAccount/{customer_id}")]
        public ActionResult<List<Account>> GetCustomerAccounts(int customer_id)
        {
            try
            {
                var acc = _AccountRepo.GetCutomerAccounts(customer_id);
                if (acc != null)
                {
                    return acc;
                }
                else
                    return NotFound();

            }
            catch (Exception e)
            {
                return NotFound(e);
            }


        }



        [HttpGet]
        [Route("getAccount/{account_id}")]
        public ActionResult GetAccount(int account_id)
        {
            if (account_id == 0)
            {
                return BadRequest();
            }
            try
            {

                var account = _AccountRepo.GetParticularAccount(account_id);
                if (account == null)
                {
                    return NotFound();
                }
                return Ok(account);

            }
            catch (Exception e)
            {
                return NotFound(e);
            }


        }
        [Route("updateAccount/{AccountId}")]
        [HttpPut("{AccountId}")]
        public async Task<IActionResult> UpdateAccount(int AccountId, Account acc)
        {
            if (AccountId == 0)
            {
                return BadRequest();
            }
            var dbAccount = _AccountRepo.GetParticularAccount(AccountId);
            dbAccount.Balance = acc.Balance;

            _accountMicroserviceDbContext.Entry(dbAccount).State = EntityState.Modified;
            try
            {

                await _accountMicroserviceDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex);
            }

        }

     

    }
}
