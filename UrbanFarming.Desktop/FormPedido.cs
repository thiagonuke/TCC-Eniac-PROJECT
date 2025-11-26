using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;

namespace UrbanFarmingDesktop.UI
{
    public partial class FormPedido : Form
    {
        private readonly RequestAPI _requestAPI;
        private List<Produtos> _produtosDisponiveis;
        private List<ItensPedido> _itensPedido;

        public FormPedido()
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            _requestAPI = new RequestAPI(httpClient);
            _itensPedido = new List<ItensPedido>();
            CarregarProdutos();
        }

        private async void CarregarProdutos()
        {
            _produtosDisponiveis = await _requestAPI.ListaProdutos();
            comboBoxProdutos.DataSource = _produtosDisponiveis;
            comboBoxProdutos.DisplayMember = "Nome";
            comboBoxProdutos.ValueMember = "Codigo";
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            var produtoSelecionado = (Produtos)comboBoxProdutos.SelectedItem;
            int quantidade;

            if (int.TryParse(textBoxQuantidade.Text, out quantidade) && quantidade > 0)
            {
                var itemPedido = new ItensPedido
                {
                    NomeProduto = produtoSelecionado.Nome,
                    CodigoProduto = produtoSelecionado.Codigo,
                    Quantidade = quantidade,
                    ValorUnitario = produtoSelecionado.Valor
                };

                _itensPedido.Add(itemPedido);
                AtualizarGridItens();
                CalcularValorTotal();
                textBoxQuantidade.Clear();
            }
            else
            {
                MessageBox.Show("Quantidade inválida!");
            }
        }

        private void AtualizarGridItens()
        {
            dataGridViewItens.DataSource = null;
            dataGridViewItens.DataSource = _itensPedido;
        }

        private void CalcularValorTotal()
        {
            decimal valorTotal = _itensPedido.Sum(i => i.Quantidade * i.ValorUnitario);
            labelValorTotal.Text = $"Valor Total: {valorTotal:C}";
        }

        private async void buttonFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (_itensPedido.Count == 0)
            {
                MessageBox.Show("Adicione itens ao pedido antes de finalizar.");
                return;
            }

            var pedido = new Pedido
            {
                ValorTotal = _itensPedido.Sum(i => i.Quantidade * i.ValorUnitario),
                Usuario = "Usuario", 
                Data = DateTime.Now,
                Itens = _itensPedido
            };

            var response = await _requestAPI.EfetuarCadastradoPedido(pedido);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Pedido realizado com sucesso!");
                _itensPedido.Clear();
                AtualizarGridItens();
                CalcularValorTotal();
            }
            else
            {
                MessageBox.Show($"Erro ao realizar o pedido: {response.ReasonPhrase}");
            }
        }
    }
}
