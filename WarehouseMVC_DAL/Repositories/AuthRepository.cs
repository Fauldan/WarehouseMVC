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
    public class AuthRepository
    {
        private HttpClient httpClient;
        public AuthRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }

        // INSERT(Utilisateur form)
        public void Register(Utilisateur form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Auth/Register", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
        // GET()
        public IEnumerable<Utilisateur> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Utilisateur").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Utilisateur[]>(json);
        }
        // GET(int id)
        public Utilisateur Get(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Utilisateur/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Utilisateur>(json);
        }
        public Utilisateur Login(string login, string password)
        {
            string JsonContent = JsonConvert.SerializeObject(new { Login = login, Password = password }, Formatting.Indented);
            HttpContent content = new StringContent( JsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync("Auth/Login", content).Result;
            
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Utilisateur>(json);
        }
    }
}
