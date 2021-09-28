using AccountMicroservice.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



namespace RulesMicroservice.Repository
{
    public class RulesRepository : IRuleRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RulesRepository));
        public List<Account> GetAccounts()
        {
            try
            {
                List<Account> acc = null;



                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5001");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Account/getAllAccounts").Result;
                var result = response.Content.ReadAsStringAsync().Result;
                acc = JsonConvert.DeserializeObject<List<Account>>(result);



                return acc;
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in getting accounts from Account API"+e);
                throw;

            }
        }



        public async Task<double> GetMinBalance(int AccountID)
        {
            try
            {
                Account acc = new Account();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:5001/api/Account/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response =await client.GetAsync("getAccount/"+AccountID);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        acc = JsonConvert.DeserializeObject<Account>(result);
                        _log4net.Info("Account details is successfully fetched in rules microservice for AccountId- " + AccountID);
                    }
                }

                return acc.MinBalance;
            }
            catch (Exception e)
            {
                _log4net.Error(e.Message);
                throw;
            }
        }
    }
}