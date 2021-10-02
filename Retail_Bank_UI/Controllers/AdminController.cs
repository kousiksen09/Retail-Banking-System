using AccountMicroservice.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Retail_Bank_UI.Controllers
{
  
    public class AdminController : Controller
    {

        public async Task<IActionResult> Index()
        {
            Client client = new Client();
            List<Account> accounts = new List<Account>();
            try {
                var result = await client.APIClient().GetAsync("/gateway/Account/getAllAccounts");
                if (result.IsSuccessStatusCode)
                {
                    var account = result.Content.ReadAsStringAsync().Result;
                    accounts = JsonConvert.DeserializeObject<List<Account>>(account);
                }
                return View(accounts);
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
            }
    }
}
