using AppMobileUrban.Services;
using AppMobileUrban.ViewModels;
using AppMobileUrban.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppMobileUrban
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Remove("Usuario");
            Application.Current.Properties.Remove("Senha");
            Application.Current.Properties.Remove("Nome");
            Application.Current.Properties.Remove("Administrador");
            await Application.Current.SavePropertiesAsync();


            await Navigation.PushAsync(new LoginPage(new requests()));
        }

    }
}
