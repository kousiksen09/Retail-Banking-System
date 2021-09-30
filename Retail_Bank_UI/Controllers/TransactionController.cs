using AccountMicroservice.Model;
using AccountMicroservice.Repositry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Retail_Bank_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TransactionMicroservice.Repository;

namespace Retail_Bank_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TransactionController : Controller
    {
        /*public async Task<Account> GetAccount(int AccountId)
        {
            Client client = new Client();
            Account acc = null;
            var response = await client.APIClient().GetAsync("/gateway/Account/getAccount/" + AccountId);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                acc = JsonConvert.DeserializeObject<Account>(result);
            }
            return acc;
        }*/

        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DepositPost(int AccountId, double amount)
        {
            Client client = new Client();
            TransactionStatus ts = new TransactionStatus();

            var DepositResponse = await client.APIClient().PostAsJsonAsync("/gateway/Transaction/Deposit", new { AccountId = AccountId, amount = amount });

            if (DepositResponse.IsSuccessStatusCode)
            {
                var result = DepositResponse.Content.ReadAsStringAsync().Result;
                ts = JsonConvert.DeserializeObject<TransactionStatus>(result);
            }
            return View(ts);
        }

        [HttpGet]
        public IActionResult Withdraw()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> WithdrawPost(int AccountId, double amount)
        {
            Client client = new Client();
            TransactionStatus ts = new TransactionStatus();

            var DepositResponse = await client.APIClient().PostAsJsonAsync("/gateway/Transaction/Withdraw", new { AccountId = AccountId, amount = amount });

            if (DepositResponse.IsSuccessStatusCode)
            {
                var result = DepositResponse.Content.ReadAsStringAsync().Result;
                ts = JsonConvert.DeserializeObject<TransactionStatus>(result);
            }
            return View(ts);
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> TransferPost(int Source_Account_Id, int Target_Account_Id, double amount)
        {
            Client client = new Client();
            TransactionStatus ts = new TransactionStatus();

            var DepositResponse = await client.APIClient().PostAsJsonAsync("/gateway/Transaction/Transfer", new {Source_Account_Id = Source_Account_Id, Target_Account_Id = Target_Account_Id, amount = amount });

            if (DepositResponse.IsSuccessStatusCode)
            {
                var result = DepositResponse.Content.ReadAsStringAsync().Result;
                ts = JsonConvert.DeserializeObject<TransactionStatus>(result);
            }
            return View(ts);
        }
    }
}
