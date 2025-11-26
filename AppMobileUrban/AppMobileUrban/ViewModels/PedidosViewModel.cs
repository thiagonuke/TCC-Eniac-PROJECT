using AppMobileUrban.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using RestSharp;
using System.Collections.Generic;

namespace AppMobileUrban.ViewModels
{
    public class PedidosViewModel : BindableObject
    {
        private RestClient client = new RestClient("http://10.0.2.2:5152");

        private ObservableCollection<Pedido> pedidos;
        public ObservableCollection<Pedido> Pedidos
        {
            get => pedidos;
            set
            {
                pedidos = value;
                OnPropertyChanged();
            }
        }

        public PedidosViewModel()
        {
            Pedidos = new ObservableCollection<Pedido>();
            LoadPedidos();
        }

        private async void LoadPedidos()
        {
            try
            {
                var request = new RestRequest("/api/Pedidos", Method.Get);
                request.AddHeader("Content-Type", "application/json");

                var response = await client.ExecuteAsync<List<Pedido>>(request);

                if (response.IsSuccessful && response.Data != null)
                {
                    Pedidos = new ObservableCollection<Pedido>(response.Data);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        public async Task CarregarPedidosAsync()
        {
            var request = new RestRequest("/api/Pedidos", Method.Get);
            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync<List<Pedido>>(request);
            if (response.IsSuccessful)
            {
                Pedidos.Clear();
                foreach (var pedido in response.Data)
                {
                    Pedidos.Add(pedido);
                }
            }
        }
    }
}