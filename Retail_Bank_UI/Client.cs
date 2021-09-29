using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Retail_Bank_UI
{
    public class Client
    {
        public HttpClient APIClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5008");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
