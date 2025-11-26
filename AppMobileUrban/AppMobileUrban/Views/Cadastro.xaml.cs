using AppMobileUrban.Models;
using AppMobileUrban.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileUrban.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        private readonly requests _request;
        public Cadastro(requests request)
        {
            InitializeComponent();
            _request = request;
        }

        private async void OnRegisterSubmitClicked(object sender, EventArgs e)
        {
            string nome = nomeEntry.Text;
            string email = emailEntry.Text;
            string senha = senhaEntry.Text;
            string repetirSenha = repetirSenhaEntry.Text;

            if (senha != repetirSenha)
            {
                senhaWarning.IsVisible = true;
                return;
            }
            else
            {
                senhaWarning.IsVisible = false;
            }

            var cadastroModel = new Login()
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Administrador = false
            };

           _request.EfetuarCadastro(cadastroModel);

           await Navigation.PushAsync(new LoginPage(new requests()));

        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}