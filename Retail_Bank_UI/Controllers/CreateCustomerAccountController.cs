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
using UserMicroService.Models;

namespace Retail_Bank_UI.Controllers
{
    
    public class CreateCustomerAccountController : Controller
    {
        // GET: CreateCustomerAccount
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAsync(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Client client = new Client();
                    CustomerCreationStatus customerCreationStatus = new CustomerCreationStatus();
                    AccountCreationStatus creationStatus = new AccountCreationStatus();
                    Customer customerDetailis = new Customer();
                    UserCred userCred = new UserCred();
                    var res1 =  client.APIClient().PostAsJsonAsync("/gateway/Customer/createCustomer", customer).Result;
                    if(res1.IsSuccessStatusCode)
                    {
                       
                        var customerStats = res1.Content.ReadAsStringAsync().Result;
                        customerCreationStatus = JsonConvert.DeserializeObject<CustomerCreationStatus>(customerStats);
                        var resultCust = await client.APIClient().GetAsync("/gateway/Customer/getCustomerDetails/" + customerCreationStatus.CustomerId);
                        if (resultCust.IsSuccessStatusCode)
                        {
                            var user = resultCust.Content.ReadAsStringAsync().Result;
                            customerDetailis = JsonConvert.DeserializeObject<Customer>(user);
                        
                        var rs2 = client.APIClient().PostAsJsonAsync("/gateway/User/createUser", customerDetailis).Result;
                            if (rs2.IsSuccessStatusCode)
                            {
                                var userCredDetails = rs2.Content.ReadAsStringAsync().Result;
                                userCred = JsonConvert.DeserializeObject<UserCred>(userCredDetails);
                                var result = client.APIClient().PostAsJsonAsync("/gateway/Account/createAccount/" + customerCreationStatus.CustomerId, customer).Result;
                                if (result.IsSuccessStatusCode)
                                {
                                    var s = result.Content.ReadAsStringAsync().Result;
                                    creationStatus = JsonConvert.DeserializeObject<AccountCreationStatus>(s);
                                    ViewData["message"] = creationStatus.Message;
                                    ViewData["CustomerId"] ="Customer Id- "+ userCred.CustomerId.ToString();
                                    ViewData["UserName"] ="UserName- " +userCred.UserName.ToString();
                                    ViewData["Password"] ="Password- "+ userCred.Password.ToString();
                                    return View();
                                }
                            }
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


        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
