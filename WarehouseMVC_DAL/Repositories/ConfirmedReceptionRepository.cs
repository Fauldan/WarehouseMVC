using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WarehouseMVC_DAL.Models;

namespace WarehouseMVC_DAL.Repositories
{
    public class ConfirmedReceptionRepository
    {
        private HttpClient httpClient;
        public ConfirmedReceptionRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }
        public void ConfirmReception(ConfirmedReception form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Reception/ConfirmReception", content).Result;
             

        }
    }
}
