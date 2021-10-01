using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using CustomerMicroService.Model;
using AccountMicroservice.Model;
using Microsoft.AspNetCore.Authorization;

namespace Retail_Bank_UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CreateCustomerAccountController : Controller
    {
        // GET: CreateCustomerAccount
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Client client = new Client();
                    CustomerCreationStatus customerCreationStatus = new CustomerCreationStatus();
                    AccountCreationStatus creationStatus = new AccountCreationStatus();
                    var res1 =  client.APIClient().PostAsJsonAsync("/gateway/Customer/createCustomer", customer).Result;
                    if(res1.IsSuccessStatusCode)
                    {
                        var customerStats = res1.Content.ReadAsStringAsync().Result;
                        customerCreationStatus = JsonConvert.DeserializeObject<CustomerCreationStatus>(customerStats);
                        var result = client.APIClient().PostAsJsonAsync("/gateway/Account/createAccount/" + customerCreationStatus.CustomerId, customer).Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var s = result.Content.ReadAsStringAsync().Result;
                             creationStatus = JsonConvert.DeserializeObject<AccountCreationStatus>(s);
                            ViewData["message"] = creationStatus.Message;
                            return View();
                        }

                    }
                }
                catch(Exception e)
                {
                    ViewData["message"] = e.Message;
                }

            }

            return View(customer);
        }

        [HttpGet]
        [Route("GetCustomerAccountDetails")]
        public async Task<IActionResult> GetCustomerAccountDetails(int CustomerId)
        {
            Client client = new Client();
            List<Account> acc = new List<Account>();

            var result = await client.APIClient().GetAsync("/gateway/Account/getCustomerAccount/" + CustomerId);
            if (result.IsSuccessStatusCode)
            {
                var s = result.Content.ReadAsStringAsync().Result;
                acc = JsonConvert.DeserializeObject<List<Account>>(s);
            }
            return View("AccountDetails", acc);

        }

        [HttpGet]
        [Route("GetAccount")]
        public async Task<IActionResult> GetAccount(int AccountId)
        {
            Client client = new Client();
            Account acc = new Account();

            var result = await client.APIClient().GetAsync("/gateway/Account/GetAccount/" + AccountId);
            if (result.IsSuccessStatusCode)
            {
                var s = result.Content.ReadAsStringAsync().Result;
                acc = JsonConvert.DeserializeObject<Account>(s);
            }
            return View("AccountDetails2", acc);

        }



    }
}
