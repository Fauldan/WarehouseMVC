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
    public class CategorieFournisseurRepository
    {
        private HttpClient httpClient;
        public CategorieFournisseurRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }

        // GET(int id)
        public IEnumerable<CategorieFournisseur> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("CategorieFournisseur").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<CategorieFournisseur[]>(json);
        }

        // INSERT(CategorieFournisseur form)
        public void Insert(CategorieFournisseur form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("CategorieFournisseur", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
    }
}
