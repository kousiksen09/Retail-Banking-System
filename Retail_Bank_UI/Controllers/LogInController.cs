using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Retail_Bank_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserMicroService.Models;

namespace Retail_Bank_UI.Controllers
{
    public class LogInController : Controller
    {
        public async Task<IEnumerable<UserCred>> GetAllUserAsync()
        {
            Client client = new Client();
            IEnumerable<UserCred> allCred = null;
            var result =await client.APIClient().GetAsync("/gateway/User/getAllUser");
            if(result.IsSuccessStatusCode)
            {
                var user = result.Content.ReadAsStringAsync().Result;
                allCred = JsonConvert.DeserializeObject<IEnumerable<UserCred>>(user);
            }
            return allCred;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LogIn logIn)
        {
            IEnumerable<UserCred> userCreds =await GetAllUserAsync();

            if (logIn.LogInType==UserType.Admin)
            {
                foreach (var item in userCreds)
                {
                    if(item.UserName==logIn.Username && item.Password==logIn.Password)
                    {
                        var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, logIn.Username),
                    new Claim(ClaimTypes.Role,"Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);


                        ViewBag.Msg = "Successfully Logged In";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Admin");
                    }
                    ViewBag.Msg = "OOPS!!Wrong Cred";
                }
               
            }
            else if(logIn.LogInType == UserType.Customer)
            {
                foreach (var item in userCreds)
                {
                    if (item.UserName == logIn.Username && item.Password == logIn.Password && item.CustomerId==logIn.CustomerId)
                    {
                       var  identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, logIn.Username),
                    new Claim(ClaimTypes.Role,"Customer")
                }, CookieAuthenticationDefaults.AuthenticationScheme);


                        ViewBag.Msg = "Successfully Logged In";
                        ModelState.Clear();
                        return RedirectToAction("Index","CustomerDetails",new {customerId= logIn.CustomerId });
                       
                    }
                    ViewBag.Msg = "OOPS!!Wrong Cred";
                }
            }

        
            return View();
        }
    }
}
