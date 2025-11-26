using AppMobileUrban.Models;
using AppMobileUrban.Services;
using AppMobileUrban.ViewModels;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace AppMobileUrban.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrinhoPage : ContentPage
    {
        private RestClient client = new RestClient("http://10.0.2.2:5152");

        private ObservableCollection<Produtos> _carrinho;
        public ObservableCollection<Produtos> Carrinho
        {
            get => _carrinho;
            set
            {
                _carrinho = value;
                OnPropertyChanged(nameof(Carrinho));
            }
        }
        public Command RemoverTodosDoCarrinhoCommand { get; }
        public Command FinalizarCompraCommand { get; }
        public Command<Produtos> RemoverDoCarrinhoCommand { get; }
        public CarrinhoPage()
        {
            InitializeComponent();
            RemoverTodosDoCarrinhoCommand = new Command(RemoverTodosDoCarrinho);
            RemoverDoCarrinhoCommand = new Command<Produtos>(RemoverDoCarrinho);
            FinalizarCompraCommand = new Command(FinalizarCompra);
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Carrinho = RecuperarCarrinhoDaSessao();
        }

        private ObservableCollection<Produtos> RecuperarCarrinhoDaSessao()
        {
            if (Application.Current.Properties.ContainsKey("Carrinho"))
            {
                var serializedCarrinho = Application.Current.Properties["Carrinho"] as string;
                if (!string.IsNullOrEmpty(serializedCarrinho))
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<Produtos>>(serializedCarrinho)
                           ?? new ObservableCollection<Produtos>();
                }
            }
            return new ObservableCollection<Produtos>();
        }

        private void RemoverTodosDoCarrinho()
        {
            Carrinho.Clear();
            SalvarSessaoCarrinho();
        }

        private void RemoverDoCarrinho(Produtos produto)
        {
            Carrinho.Remove(produto);
            SalvarSessaoCarrinho();
        }

        private void SalvarSessaoCarrinho()
        {
            Application.Current.Properties["Carrinho"] = JsonConvert.SerializeObject(Carrinho);
            Application.Current.SavePropertiesAsync();
        }

        private async void FinalizarCompra()
        {
            if (Carrinho == null || Carrinho.Count == 0)
            {
                await DisplayAlert("Carrinho vazio", "Adicione itens ao carrinho antes de finalizar a compra.", "OK");
                return;
            }

            var pedido = new Pedido()
            {
                Data = DateTime.Now,
                Usuario = Application.Current.Properties["Usuario"].ToString(),
                ValorTotal = await recuperaValorTotal(),
                Itens = await retornaItens()

            };


            var request = new RestRequest($"/api/Pedidos/CadastrarPedido", Method.Post);

            var dadosJ = JsonConvert.SerializeObject(pedido);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(dadosJ);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Sucesso", "Compra finalizada com sucesso!", "OK");
                Carrinho.Clear(); 
                SalvarSessaoCarrinho(); 
            }

        }

        private async Task<decimal> recuperaValorTotal()
        {
            decimal valor = 0;

            var items = RecuperarCarrinhoDaSessao();

            foreach (var item in items)
            {
                valor = valor + item.Valor;

            }

            return valor;   

        }
        private async Task<List<ItensPedido>> retornaItens()
        {
            var retorno = new List<ItensPedido>();

            var items = RecuperarCarrinhoDaSessao();

            foreach(var item in items)
            {
                var quanti = (from i in items
                              where item.Codigo == i.Codigo
                              select i).ToList();

                retorno.Add(new ItensPedido()
                {
                    NomeProduto = item.Nome,
                    CodigoProduto = item.Codigo,
                    Quantidade = quanti.Count(),
                    ValorUnitario = item.Valor


                });
            }

            return retorno; 

        }

    }
}