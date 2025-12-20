using AppMobileUrban.Models;
using AppMobileUrban.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.ComponentModel;
using Xamarin.Forms;


namespace AppMobileUrban.Views
{
    public partial class FornecedorPage : ContentPage
    {
        private RestClient client = new RestClient("http://10.0.2.2:5152");

        public FornecedorPage()
        {
            InitializeComponent();
        }


        private void OnPessoaSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (PessoaSwitch.IsToggled)
            {
                CnpjEntry.IsVisible = true;
                CpfEntry.IsVisible = false;
            }
            else
            {
                CnpjEntry.IsVisible = false;
                CpfEntry.IsVisible = true;
            }
        }

        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            var fornecedor = new Fornecedores
            {
                RazaoSocial = RazaoSocialEntry.Text,
                NomeFantasia = NomeFantasiaEntry.Text,
                Email = EmailEntry.Text,
                PaisOrigem = PaisOrigemEntry.Text,
                MensagemPadraoEmail = MensagemPadraoEntry.Text
            };

            if (PessoaSwitch.IsToggled)
            {
                fornecedor.CNPJ = CnpjEntry.Text;
                fornecedor.PessoaJuridica = true;
                fornecedor.PessoaFisica = false;
            }
            else
            {
                fornecedor.CNPJ = null;
                fornecedor.PessoaJuridica = false;
                fornecedor.PessoaFisica = true;
            }



            var request = new RestRequest($"/api/Fornecedores", Method.Post);

            var dadosJ = JsonConvert.SerializeObject(fornecedor);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(dadosJ);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Fornecedor Cadastrado", "Fornecedor cadastrado com sucesso!", "OK");

            }
        }
    }
}