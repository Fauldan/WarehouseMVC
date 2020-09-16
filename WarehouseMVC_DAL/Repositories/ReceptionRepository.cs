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
    public class ReceptionRepository
    {
        private HttpClient httpClient;
        public ReceptionRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }

        public IEnumerable<Reception> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Reception").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Reception[]>(json);
        }

        public Reception Get(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Reception/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Reception>(json);
        }

        public void Insert(Reception form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Reception/Create", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        } 

        public void Update(int id, Reception form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PutAsync($"Reception/{id}", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

        public void Delete(int id)
        {
            HttpResponseMessage response = httpClient.DeleteAsync($"Reception/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la suppression des données.");
            }
            return;
        }

    }
}
