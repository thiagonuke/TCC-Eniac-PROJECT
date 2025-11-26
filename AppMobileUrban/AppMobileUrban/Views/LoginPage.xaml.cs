using AppMobileUrban.Services;
using AppMobileUrban.ViewModels;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using RestSharp;
using static Xamarin.Forms.Internals.GIFBitmap;
using System.Net.Http;
using Newtonsoft.Json;
using AppMobileUrban.Models;

using System.Resources;
using System.Collections.ObjectModel;

namespace AppMobileUrban.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly requests _request;
        private readonly HttpClient _client = new HttpClient();
        public LoginPage(requests request)
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            _request = request; 
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string senha = senhaEntry.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }


            try
            {
                if (Application.Current.Properties.ContainsKey("Carrinho"))
                {
                    var serializedCarrinho = Application.Current.Properties["Carrinho"] as string;
                    if (!string.IsNullOrEmpty(serializedCarrinho))
                    {
                        Application.Current.Properties["Carrinho"] = "";
                    }
                }

                var loginResponse = await _request.EfetuarLogin(email, senha);

                if (loginResponse.Email != null)
                {
                    SaveUserSession(loginResponse);

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await DisplayAlert("Erro", "Login ou senha inválidos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new Cadastro(new requests()));
        }

        public void SaveUserSession(Login userSession)
        {
            Application.Current.Properties["Usuario"] = userSession.Email;
            Application.Current.Properties["Senha"] = userSession.Senha;
            Application.Current.Properties["Nome"] = userSession.Nome;
            Application.Current.Properties["Administrador"] = userSession.Administrador;
            Application.Current.SavePropertiesAsync(); 
        }

    }


    
}