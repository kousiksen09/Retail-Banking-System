using AccountMicroservice.Model;
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
    public class TransactionViewController : Controller
    {

        public IActionResult Deposit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deposit(Deposit _deposit)
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


                }
                return View();
            }
        }
        public IActionResult Withdraw()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Withdraw(Deposit _deposit)
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


                }
                return View();
            }
        }
        //Transfer
        public IActionResult Transfer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Transfer(Transfer transfer)
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


                }
                return View();
            }
        }




    }
    }
