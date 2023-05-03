using App_Tienda_Online.Models;
using App_Tienda_Online.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace App_Tienda_Online.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class PageInicio : ContentPage
    {
        private readonly ProductsViewModel _viewModel;


        public PageInicio()
        {
            InitializeComponent();

            _viewModel = new ProductsViewModel();
            BindingContext = _viewModel;


            UpdateButtonColors();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.GetProductsAsync();
        }

      
        private void InicioButton_Clicked(object sender, EventArgs e)
        {
            Inicio.IsVisible = true;
            Promos.IsVisible = false;
            Envio.IsVisible = false;
            UpdateButtonColors();

        }

        private void PromosButton_Clicked(object sender, EventArgs e)
        {
            Inicio.IsVisible = false;
            Promos.IsVisible = true;
            Envio.IsVisible = false;
            UpdateButtonColors();

        }

        private void EnvioButton_Clicked(object sender, EventArgs e)
        {
            Inicio.IsVisible = false;
            Promos.IsVisible = false;
            Envio.IsVisible = true;
            UpdateButtonColors();
            


        }
        private void Slider_PositionChanged(object sender, PositionChangedEventArgs e)
        {

            UpdateButtonColors();
        }
        private void UpdateButtonColors()
        {
            InicioButton.Style = Inicio.IsVisible == true ? (Style)Resources["selectedButtonStyle"] : (Style)Resources["selectedButtonStyle2"];
            PromosButton.Style = Promos.IsVisible == true ? (Style)Resources["selectedButtonStyle"] : (Style)Resources["selectedButtonStyle2"];
            EnvioButton.Style = Envio.IsVisible == true ? (Style)Resources["selectedButtonStyle"] : (Style)Resources["selectedButtonStyle2"];
        }

        private async void BtnProduct_Clicked(object sender, EventArgs e)
        {
            var button = sender as Xamarin.Forms.Button;
            var product = button?.BindingContext as Product;
            if (product == null) return;

            await Navigation.PushModalAsync(new ProductoContenido(product));
            Console.WriteLine("as----"+ product.title.ToString());
        }
    }
}