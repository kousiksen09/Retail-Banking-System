﻿using AccountMicroservice.Model;
using AccountMicroservice.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        private readonly IAccountCreationStatusRepository _AccountCreationStatusrepo;

        private readonly IAccountRepository _AccountRepo;

        private readonly IStatementRepository _statementrepo;

        public AccountController(IAccountCreationStatusRepository repo, IAccountRepository AccountRepo, IStatementRepository StatementRepo)
        {
            _AccountCreationStatusrepo = repo;
            _AccountRepo = AccountRepo;
            _statementrepo = StatementRepo;
        }

        //https://localhost:44352/api/Account/GetCreationStatus/2

        [HttpPost("{customer_id}")]
        [Route("createAccount/{customer_id}")]
        public ActionResult CreteAccount(int customer_id)
        {
            try
            {
                var newaccount = _AccountRepo.CreateAccount(customer_id);

                var creationstatus = _AccountCreationStatusrepo.GetCreationStatus(newaccount.Cur_AccountId, newaccount.Sav_AccountId);
                return Ok(creationstatus);
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
                return acc;
            }
            catch(Exception e)
            {
                return NotFound();
            }


        }


        [HttpGet]
        [Route("getAccount/{account_id}")]
        public ActionResult GetAccount(int account_id)
        {
            try
            {
                var account = _AccountRepo.GetPerticularAccount(account_id);
                return Ok(account);
            }
            catch (Exception e)
            {
                return NotFound();
            }


        }

        

        [HttpGet]
        [Route("getAccountStatement/{account_id}")]
        public ActionResult<Statement> GetAccountStatemnet(int account_id,DateTime fromdate, DateTime todate)
        {
            try
            {
                var statement = _statementrepo.GetStatement(account_id, fromdate, todate);
                return Ok(statement);
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }

        


        



    }
}