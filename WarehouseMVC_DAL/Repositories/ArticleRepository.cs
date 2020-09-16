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
    public class ArticleRepository
    {
        private HttpClient httpClient;
        public ArticleRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }
                // GET()
        public IEnumerable<Article> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Article").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Article[]>(json);
        }

                // GET(int id)
        public Article Get(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Article/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Article>(json);
        }    

                // INSERT(Article form)
        public void Insert(Article form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Article", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

                // UPDATE(int id, Article form)
        public void Update(int id, Article form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PutAsync($"Article/{id}", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

                // DELETE(int id)
        public void Delete(int id)
        {
            HttpResponseMessage response = httpClient.DeleteAsync($"Article/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la suppression des données.");
            }
            return;
        }

    }
}

