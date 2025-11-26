using AppMobileUrban.Models;
using AppMobileUrban.Views;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace AppMobileUrban.ViewModels
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Produtos> _items;
        private string _name;
        private bool _isAdmin;
        private RestClient client = new RestClient("http://10.0.2.2:5152");


        private const string Url = "http://10.0.2.2:5152";

        public ObservableCollection<Produtos> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public ObservableCollection<Produtos> Carrinho { get; set; } 
        public Command<Produtos> AdicionarAoCarrinhoCommand { get; }
        public Command<Produtos> RemoverDoCarrinhoCommand { get; }

        public Command FinalizarCompraCommand { get; }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    OnPropertyChanged(nameof(IsAdmin));
                }
            }
        }

        public Command CadastrarProdutoCommand { get; }
        public Command IrParaCarrinhoCommand { get; }
        public Command<Produtos> DeletarProdutoCommand { get; }


        public ItemsViewModel()
        {
            Items = new ObservableCollection<Produtos>();
            Carrinho = new ObservableCollection<Produtos>(); 
            AdicionarAoCarrinhoCommand = new Command<Produtos>(OnAdicionarAoCarrinho);
            FinalizarCompraCommand = new Command(OnFinalizarCompra);
            IrParaCarrinhoCommand = new Command(OnIrParaCarrinho);
            RemoverDoCarrinhoCommand = new Command<Produtos>(OnRemoverDoCarrinho);
            DeletarProdutoCommand = new Command<Produtos>(onDeleteProduct);
            Carrinho = RecuperarCarrinhoDaSessao();

            LoadItems();
            LoadUserSession();
        }
        private void OnAdicionarAoCarrinho(Produtos produto)
        {
            Carrinho.Add(produto);
            SaveCarrinhoSession();
            OnPropertyChanged(nameof(Carrinho));
        }
        private void OnRemoverDoCarrinho(Produtos produto)
        {
            Carrinho.Remove(produto);
            SaveCarrinhoSession();
            OnPropertyChanged(nameof(Carrinho));
        }
        private void SaveCarrinhoSession()
        {
            Application.Current.Properties["Carrinho"] = JsonConvert.SerializeObject(Carrinho);
            Application.Current.SavePropertiesAsync(); 
        }

        private ObservableCollection<Produtos> RecuperarCarrinhoDaSessao()
        {
            if (Application.Current.Properties.ContainsKey("Carrinho"))
            {
                var serializedCarrinho = Application.Current.Properties["Carrinho"] as string;
                if (!string.IsNullOrEmpty(serializedCarrinho))
                {
                    var produtos = JsonConvert.DeserializeObject<ObservableCollection<Produtos>>(serializedCarrinho);
                    return produtos ?? new ObservableCollection<Produtos>();
                }
            }
            return new ObservableCollection<Produtos>();
        }

        private async void OnIrParaCarrinho()
        {
            await Shell.Current.GoToAsync("//CarrinhoPage");
        }
        private async void OnFinalizarCompra()
        {
            string resumoCompra = string.Join("\n", Carrinho.Select(p => $"{p.Nome} - {p.Valor:C}"));
            await Application.Current.MainPage.DisplayAlert("Resumo da Compra", resumoCompra, "OK");
            Carrinho.Clear();
            OnPropertyChanged(nameof(Carrinho));
        }

        private async void LoadItems()
        {
            var client = new RestClient(Url);
            var request = new RestRequest("/api/Produtos/GetAllProdutos", Method.Get);
            var response = client.Execute(request);

            var items = JsonConvert.DeserializeObject<List<Produtos>>(response.Content);

            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        private void LoadUserSession()
        {
            if (Application.Current.Properties.ContainsKey("Nome"))
            {
                Name = Application.Current.Properties["Nome"] as string;
            }

            if (Application.Current.Properties.ContainsKey("Administrador"))
            {
                IsAdmin = (bool)Application.Current.Properties["Administrador"];
            }
        }
        private async void onDeleteProduct(Produtos produto)
        {
            var request = new RestRequest($"/api/Produtos/{produto.Codigo}", Method.Delete);

            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Items.Remove(produto);
                OnPropertyChanged(nameof(Items));
                await Application.Current.MainPage.DisplayAlert("Sucesso", "Produto excluído com sucesso", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível excluir o produto", "OK");
            }
        }

        private async void OnCadastrarProduto()
        {

            await Shell.Current.GoToAsync("CadastroProdutoPage");

            await Shell.Current.GoToAsync("..", true);
        }

        public async void LoadItemsAsync()
        {
            Items.Clear();
            var request = new RestRequest("/api/Produtos/GetAllProdutos", Method.Get);
            var response = await client.ExecuteAsync(request);

            var items = JsonConvert.DeserializeObject<List<Produtos>>(response.Content);
            if (items != null)
            {
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
