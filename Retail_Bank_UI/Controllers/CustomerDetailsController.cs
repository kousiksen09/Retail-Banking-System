using AccountMicroservice.Model;
using CustomerMicroService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Retail_Bank_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace Retail_Bank_UI.Controllers
{

    public class CustomerDetailsController : Controller
    {
        [HttpGet]

        public async Task<IActionResult> Index(int customerId)
        {
            Client client = new Client();
            Customer customer = new Customer();

            List<Account> accounts = new List<Account>();
            try
            {


                var result = await client.APIClient().GetAsync("/gateway/Customer/getCustomerDetails/" + customerId);
                var apiAcc = await client.APIClient().GetAsync("/gateway/Account/getCustomerAccount/" + customerId);
                if (result.IsSuccessStatusCode)
                {
                    var user = result.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(user);
                }
                if (apiAcc.IsSuccessStatusCode)
                {
                    var account = apiAcc.Content.ReadAsStringAsync().Result;
                    accounts = JsonConvert.DeserializeObject<List<Account>>(account);

                    ViewData["AccountInfo"] = accounts;
                }

                return View(customer);
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
        



        public IActionResult Statement(int AccountId)
        {
            ViewBag.AccountId = AccountId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Statement(int AccountId, StatementUI statement)
        {
            Client client = new Client();
            List<Statement> statements = new List<Statement>();
            statement.AccountId = AccountId;
            try
            {
                var result = await client.APIClient().GetAsync("/gateway/Transaction/getStatement/" + statement.AccountId + "/" + statement.FromDate.ToString("yyyy-MM-dd HH:mm:ss") + "/" + statement.ToDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (result.IsSuccessStatusCode)
                {
                    var s = result.Content.ReadAsStringAsync().Result;
                    statements = JsonConvert.DeserializeObject<List<Statement>>(s);
                }
                return View("StatementDetails", statements);
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }


    }
}
