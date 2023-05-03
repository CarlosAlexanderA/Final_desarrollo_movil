using App_Tienda_Online.Services;
using App_Tienda_Online.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Tienda_Online
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
