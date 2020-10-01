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
    public class StockRepository
    {
        private HttpClient httpClient;
        public StockRepository()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56573/api/");
        }

        public IEnumerable<Stock> Get()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Stock/Get").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Stock[]>(json);
        }

        public Stock Get(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Stock/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Stock>(json);
        }

        public void Insert(Reception form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Stock", content).Result;
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
            return;
        }

        public void ConfirmReception(ConfirmedReception form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Reception/ConfirmReception", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
        public void ConfirmExpedition(ConfirmedExpedition form)
        {
            string body = JsonConvert.SerializeObject(form);

            HttpContent content = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage message = httpClient.PostAsync("Expedition/ConfirmExpedition", content).Result;
            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
        public Stock GetStockArticle(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Stock/GetStockArticle/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Stock>(json);
        }
        public IEnumerable<Stock> GetMoveStock_By_ArticleId(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"Stock/GetMoveStock_By_ArticleId/{id}").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Stock[]>(json);
        }        
        public IEnumerable<Stock> GetStockInventaire()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Stock/GetStockInventaire").Result;
            httpResponseMessage.EnsureSuccessStatusCode();

            string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Stock[]>(json);
        }
    }
}
