using AccountMicroservice.Model;
using CustomerMicroService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Retail_Bank_UI.Models;
using Retail_Bank_UI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TransactionMicroservice.Models;

namespace Retail_Bank_UI.Controllers
{
    public class TransactionViewController : Controller
    {
        private IEmailSender emailSender;
        private ISMSsender _SMSsender;
    
        public TransactionViewController(IEmailSender email, ISMSsender sms)
        {
            emailSender = email;
            _SMSsender = sms;
        }


        private async Task<Customer> GetCustomer(int CustomerId)
        {
            Client client = new Client();
            Customer customer = new Customer();
            var result = await client.APIClient().GetAsync("/gateway/Customer/getCustomerDetails/" + CustomerId);

            if (result.IsSuccessStatusCode)
            {
                var user = result.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(user);
            }
            return customer;
        }

        private async Task<Account> GetAccount(int AccountId)
        {
            Client client = new Client();
            Account account = new Account();
            var result = await client.APIClient().GetAsync("/gateway/Account/GetAccount/" + AccountId);
            if (result.IsSuccessStatusCode)
            {
                var s = result.Content.ReadAsStringAsync().Result;
                account = JsonConvert.DeserializeObject<Account>(s);
            }
            return account;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Deposit()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DepositAsync(Deposit _deposit)
        {
            TransactionStatus status = new TransactionStatus();

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:5000/api/Transaction/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client.PostAsJsonAsync("Deposit", _deposit).Result;
                if (response1.IsSuccessStatusCode)
                {
                    var s = response1.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<TransactionStatus>(s);
                    ViewData["message"] = status.Message;
                    Account account = await GetAccount(_deposit.AccountId);
                    var cts = await GetCustomer(account.CustomerId);
                    
                    
                    string message = $"Hi {cts.Name},\n" +
                        $"{status.Message} to Your {account.accountType} Account No {_deposit.AccountId}. \n" +
                        $"Your Current Balance is {status.destination_balance}. \n" +
                        $"Thank You For Connecting with Us. \n" +
                        $"With Regards, \nTeam Retail Bank.";
                    if (cts.Email == null)
                    {
                        _SMSsender.SendSMS("+919382117960", message);
                    }
                    else
                    {
                        await emailSender.SendEmailAsync(cts.Email, "Account Summary", message);
                        _SMSsender.SendSMS("+919382117960", message);
                    }

                }
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Withdraw()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> WithdrawAsync(Deposit _deposit)
        {
            TransactionStatus status = new TransactionStatus();

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:5000/api/Transaction/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client.PostAsJsonAsync("Withdraw", _deposit).Result;
                if (response1.IsSuccessStatusCode)
                {
                    var s = response1.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<TransactionStatus>(s);
                    ViewData["message"] = status.Message;
                    Account account = await GetAccount(_deposit.AccountId);
                    var cts = await GetCustomer(account.CustomerId);


                    string message = $"Hi {cts.Name}, <br> {status.Message} to Your {account.accountType} Account No {_deposit.AccountId} <br> Your Current Balance is {status.destination_balance}. <br> Thank You For Connecting with Us. <br> Please do not reply to this mail as this is an automated mail service. <br><br><b> With Regards, <br> Team Retail Bank</b>";
                    await emailSender.SendEmailAsync(cts.Email, "Account Summary", message);

                }
                return View();
            }
        }
        //Transfer

        [Authorize(Roles = "Admin")]
        public IActionResult Transfer()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> TransferAsync(Transfer transfer)
        {
            TransactionStatus status = new TransactionStatus();

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:5000/api/Transaction/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response1 = client.PostAsJsonAsync("Transfer", transfer).Result;
                if (response1.IsSuccessStatusCode)
                {
                    var s = response1.Content.ReadAsStringAsync().Result;
                    status = JsonConvert.DeserializeObject<TransactionStatus>(s);
                    ViewData["message"] = status.Message;

                    Account account = await GetAccount(transfer.Source_ACC_ID);
                    var cts = await GetCustomer(account.CustomerId);


                    string message = $"Hi {cts.Name}, <br> {status.Message} to Your {account.accountType} Account No {transfer.Source_ACC_ID} <br> Your Current Balance is {status.destination_balance}. <br> Thank You For Connecting with Us. <br> Please do not reply to this mail as this is an automated mail service. <br><br><b> With Regards, <br> Team Retail Bank</b>";
                    await emailSender.SendEmailAsync(cts.Email, "Account Summary", message);
                }
                return View();
            }
        }
    }
    }
