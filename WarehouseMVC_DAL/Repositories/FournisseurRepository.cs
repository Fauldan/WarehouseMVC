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
    public class FournisseurRepository
    {
        private HttpClient httpClient;
        public FournisseurRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }

                // GET()
        public IEnumerable<Fournisseur> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Fournisseur").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Fournisseur[]>(json);
        }

                // GET(int id)
        public Fournisseur Get(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Fournisseur/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Fournisseur>(json);
        }

        //        // GET(int articleId)
        public IEnumerable<Fournisseur> GetByArticle(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Fournisseur/GetByArticle/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Fournisseur[]>(json);
        }

        // INSERT(Fournisseur form)
        public void Insert(Fournisseur form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Fournisseur", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
        
                // UPDATE(int id, Fournisseur form)
        public void Update(int id, Fournisseur form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PutAsync($"Fournisseur/{id}", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

                // DELETE(int id)
        public void Delete(int id)
        {
            HttpResponseMessage response = httpClient.DeleteAsync($"Fournisseur/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la suppression des données.");
            }
            return;
        }
    }
}
