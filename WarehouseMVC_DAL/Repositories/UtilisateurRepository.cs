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
    public class UtilisateurRepository
    {
        private HttpClient httpClient;
        public UtilisateurRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
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
    }
}
