using App_Tienda_Online.Models;
using App_Tienda_Online.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Tienda_Online.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCategoria : ContentPage
    {
        private readonly CategoriesViewModel _viewModel;

        public PageCategoria()
        {
            InitializeComponent();
            _viewModel = new CategoriesViewModel();
            BindingContext = _viewModel;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.GetCategoriesAsync();
        }


    }
}