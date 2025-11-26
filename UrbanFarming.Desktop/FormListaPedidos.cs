using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;

namespace UrbanFarmingDesktop.UI
{
    public partial class FormListaPedidos : Form
    {
        private readonly RequestAPI _requestAPI;
        private List<PedidoViewModel> _pedidos;

        public FormListaPedidos()
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            _requestAPI = new RequestAPI(httpClient);
            CarregarPedidos();
            dataGridViewPedidos.CellClick += DataGridViewPedidos_CellClick;
        }

        private async void CarregarPedidos()
        {
            _pedidos = await ObterPedidos();
            var displayList = _pedidos.Select(p => new
            {
                p.CodigoPedido,
                p.ValorTotal,
                p.Usuario,
                p.Data
            }).ToList();

            dataGridViewPedidos.DataSource = displayList;
        }

        private async Task<List<PedidoViewModel>> ObterPedidos()
        {
            var pedidos = await _requestAPI.ListaPedidos();
            var pedidoViewModels = new List<PedidoViewModel>();

            foreach (var pedido in pedidos)
            {
                pedidoViewModels.Add(new PedidoViewModel
                {
                    CodigoPedido = pedido.CodigoPedido,
                    ValorTotal = pedido.ValorTotal,
                    Usuario = pedido.Usuario,
                    Data = pedido.Data,
                    Itens = pedido.Itens ?? new List<ItensPedido>()
                });
            }

            return pedidoViewModels;
        }

        private void DataGridViewPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedPedido = _pedidos[e.RowIndex];
                ShowItensPedido(selectedPedido);
            }
        }

        private void ShowItensPedido(PedidoViewModel pedido)
        {
            var itensForm = new FormItensPedido(pedido.Itens);
            itensForm.ShowDialog();
        }
    }

    public class PedidoViewModel
    {
        public int CodigoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }
        public List<ItensPedido> Itens { get; set; }
    }
}
