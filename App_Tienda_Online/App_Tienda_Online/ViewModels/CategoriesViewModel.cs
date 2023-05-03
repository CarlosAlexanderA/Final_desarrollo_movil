using App_Tienda_Online.Models;
using App_Tienda_Online.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App_Tienda_Online.ViewModels
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Category> _categories { get; set; }

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<Category>();
        }



        public async Task GetCategoriesAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://dummyjson.com/products/categories");
            var json = await response.Content.ReadAsStringAsync();
            var categoryStrings = JsonConvert.DeserializeObject<List<string>>(json);

            foreach (var categoryString in categoryStrings)
            {
                Categories.Add(GetCategoryFromString(categoryString));
            }



        }
        private Category GetCategoryFromString(string categoryString)
        {
            // Aquí puedes implementar la lógica para convertir una cadena en un objeto Category
            return new Category { Name = categoryString };
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
