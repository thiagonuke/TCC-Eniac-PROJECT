using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;

namespace UrbanFarming.Desktop
{
    public partial class FormDelProdutos : Form
    {
        private readonly RequestAPI _requestAPI;

        public FormDelProdutos()
        {
            InitializeComponent();
            _requestAPI = new RequestAPI(new HttpClient());
        }

        private async void FormDelProdutos_Load(object sender, EventArgs e)
        {
            await CarregarListaProdutos();
        }

        private async Task CarregarListaProdutos()
        {
            var produtos = await _requestAPI.ListaProdutos();
            dgvProdutos.DataSource = produtos;
        }

        private async void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                var codigoProduto = dgvProdutos.SelectedRows[0].Cells["Codigo"].Value.ToString();

                var response = await _requestAPI.EfetuarDeleteProduto(codigoProduto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Produto deletado com sucesso!");
                    await CarregarListaProdutos();
                }
                else
                {
                    MessageBox.Show("Erro ao deletar o produto.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para deletar.");
            }
        }
    }
}
