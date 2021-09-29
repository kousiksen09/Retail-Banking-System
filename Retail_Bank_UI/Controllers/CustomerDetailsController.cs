using AccountMicroservice.Model;
using CustomerMicroService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Retail_Bank_UI.Controllers
{
   
    public class CustomerDetailsController : Controller
    {
        [HttpGet]
       
        public async Task<IActionResult> Index(int? customerId)
        {
            Client client = new Client();
            Customer customer = new Customer();
            
            List<Account> accounts = new List<Account>();
            var result = await client.APIClient().GetAsync("/gateway/Customer/getCustomerDetails/"+customerId);
            var apiAcc = await client.APIClient().GetAsync("/gateway/Account/getCustomerAccount/" + customerId);
            if (result.IsSuccessStatusCode)
            {
                var user = result.Content.ReadAsStringAsync().Result;
                customer= JsonConvert.DeserializeObject<Customer>(user);
            }
            if(apiAcc.IsSuccessStatusCode)
            {
                var account = apiAcc.Content.ReadAsStringAsync().Result;
                accounts = JsonConvert.DeserializeObject<List<Account>>(account);

                ViewData["AccountInfo"] = accounts;
            }
            return View(customer);
        }
    }
}
