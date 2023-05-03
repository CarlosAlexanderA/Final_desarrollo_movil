using App_Tienda_Online.Models;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App_Tienda_Online.Services
{
    public class ApiService
    {
        private const string BaseUrl = "https://dummyjson.com/products";

        public async Task<List<Product>> GetProductsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(BaseUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<List<Product>>(content);
                    return products;
                }
                return null;
            }
        }
        
    }


}
