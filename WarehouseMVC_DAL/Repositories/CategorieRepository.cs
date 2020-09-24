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
    public class CategorieRepository
    {

        private HttpClient httpClient;
        public CategorieRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }
        // GET()
        public IEnumerable<Categorie> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Categorie").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Categorie[]>(json);
        }

        // GET(int id)
        public Categorie Get(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Categorie/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Categorie>(json);
        }

        // GET(int id)
        public IEnumerable<Categorie> GetCategorie_NotIn_Fournisseur(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Categorie/GetCategorie_NotIn_Fournisseur/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Categorie[]>(json);
        }

        // GET(int id)
        public IEnumerable<Categorie> GetCategorie_By_Fournisseur(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Categorie/GetCategorie_By_Fournisseur/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Categorie[]>(json);
        }

        // INSERT(Categorie form)
        public void Insert(Categorie form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Categorie", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

        // UPDATE(int id, Categorie form)
        public void Update(int id, Categorie form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PutAsync($"Categorie/{id}", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

        // DELETE(int id)
        public void Delete(int id)
        {
            HttpResponseMessage response = httpClient.DeleteAsync($"Categorie/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la suppression des données.");
            }
            return;
        }

    }
}
