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


        [HttpGet]
        [Route("/Account/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LogIn logIn)
        {
            IEnumerable<UserCred> userCreds =await GetAllUserAsync();
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            bool isAdmin = false;

            if (logIn.LogInType==UserType.Admin)
            {
                foreach (var item in userCreds)
                {
                    if(item.UserName==logIn.Username && item.Password==logIn.Password)
                    {
                        
                         identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, logIn.Username),
                    new Claim(ClaimTypes.Role,"Admin")
                   
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                        isAuthenticate = true;
                        isAdmin = true;
                        ViewBag.Msg = "Successfully Logged In";
                        ModelState.Clear();
                       
                    }
                    ViewBag.Msg = "OOPS!!Wrong Cred";
                }
               
            }
            if(logIn.LogInType == UserType.Customer)
            {
                foreach (var item in userCreds)
                {
                    if (item.UserName == logIn.Username && item.Password == logIn.Password && item.CustomerId==logIn.CustomerId)
                    {
                         identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, logIn.Username),
                    new Claim(ClaimTypes.Role,"Customer")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                        isAuthenticate = true;
                        isAdmin = false;
                        ViewBag.Msg = "Successfully Logged In";
                        ModelState.Clear();
                        
                       
                    }
                    ViewBag.Msg = "OOPS!!Wrong Cred";
                }
            }

            if(isAuthenticate)
            {
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    

                };
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    authProperties);
               // var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,authProperties);
                if(isAdmin)
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "CustomerDetails", new { customerId = logIn.CustomerId });
            }
         
                return View("AccessDenied");
            
      
        }
    }
}
