using AppMobileUrban.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileUrban.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroProdutoPage : ContentPage
    {
        private requests _request;
        public CadastroProdutoPage(requests requests)
        {
            _request = requests;
            InitializeComponent();
        }

        private async void OnRegisterProdSubmitClicked(object sender, EventArgs e)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(CodEntry.Text))
            {
                CodError.IsVisible = true;
                isValid = false;
            }
            else
            {
                CodError.IsVisible = false;
            }

            if (string.IsNullOrWhiteSpace(NomeEntry.Text))
            {
                NomeError.IsVisible = true;
                isValid = false;
            }
            else
            {
                NomeError.IsVisible = false;
            }

            if (string.IsNullOrWhiteSpace(ValorEntry.Text))
            {
                ValorError.IsVisible = true;
                isValid = false;
            }
            else
            {
                ValorError.IsVisible = false;
            }

            if (string.IsNullOrWhiteSpace(DescriEntry.Text))
            {
                DescriError.IsVisible = true;
                isValid = false;
            }
            else
            {
                DescriError.IsVisible = false;
            }

            if (string.IsNullOrWhiteSpace(LinkEntry.Text))
            {
                LinkError.IsVisible = true;
                isValid = false;
            }
            else
            {
                LinkError.IsVisible = false;
            }

            if (!isValid)
            {
                ErrorLabel.Text = "Por favor, preencha todos os campos obrigatórios.";
                ErrorLabel.IsVisible = true;
                return;
            }

            ErrorLabel.IsVisible = false;

            try
            {
                _request.EfetuarCadastroProduto(new Models.Produtos()
                {
                    Codigo = CodEntry.Text,
                    Nome = NomeEntry.Text,
                    Valor = Convert.ToDecimal(ValorEntry.Text),
                    Descricao = DescriEntry.Text,
                    LinkImagem = LinkEntry.Text
                });

                await DisplayAlert("Sucesso", "Produto cadastrado com sucesso!", "OK");

                await Navigation.PopAsync();
            }
            catch (Exception ex) {

                if (ex.Message.Contains("decimal"))
                {
                    await DisplayAlert("Erro", "Preencha o campo de Valor corretamente!", "OK");

                }
            } 

        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
