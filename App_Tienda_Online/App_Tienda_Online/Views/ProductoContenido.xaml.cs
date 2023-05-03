using App_Tienda_Online.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Tienda_Online.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoContenido : ContentPage
    {
        public ProductoContenido(Product product)
        {
            InitializeComponent();
            BindingContext = product;
            // Asume que tienes una variable rating con el valor de la calificación
            int rating = 4;

            StackLayout starLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, 10, 0, 0)
            };

            List<Image> stars = GenerateStars(rating);

            foreach (Image star in stars)
            {
                starLayout.Children.Add(star);
            }

            // Añade la etiqueta con el valor de rating
            //starLayout.Children.Add(new Label { Text = rating.ToString(), FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label)), TextColor = Color.FromHex("#333333"), Margin = new Thickness(10, 0, 0, 0) });

            star_logg.Children.Add(starLayout);

        }

        private async void Cerrar_Modal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private List<Image> GenerateStars(int rating)
        {
            List<Image> stars = new List<Image>();

            for (int i = 0; i < rating; i++)
            {
                stars.Add(new Image { Source = "star.png", WidthRequest = 20, HeightRequest = 20});
            }

            for (int i = rating; i < 5; i++)
            {
                stars.Add(new Image { Source = "star_empty.png", WidthRequest = 20, HeightRequest = 20 });
            }

            return stars;
        }

    }
}