using App_Tienda_Online.Models;
using App_Tienda_Online.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App_Tienda_Online.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;


        public ObservableCollection<Product> Products { 
            get => _products;
            set {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>();
        }

        public async Task GetProductsAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://dummyjson.com/products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var root = JsonConvert.DeserializeObject<Root>(content);
                    foreach (var product in root.products)
                    {
                        Products.Add(product);
                    }
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
