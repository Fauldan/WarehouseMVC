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
    public class ClientRepository
    {
        private HttpClient httpClient;
        public ClientRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        } 
                // GET()
        public IEnumerable<Client> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Client").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Client[]>(json);
        }

                // GET(int id)
        public Client Get(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Client//{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Client>(json);
        }

                // INSERT(Client form)
        public void Insert(Client form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Client", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

                // UPDATE(int id, Client form)
        public void Update(int id, Client form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PutAsync($"Client/{id}", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

                // DELETE(int id)
        public void Delete(int id)
        {
             HttpResponseMessage response = httpClient.DeleteAsync($"Client/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la suppression des données.");
            }
            return;
        }
    }
}
