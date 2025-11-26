using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request; // Certifique-se de que as classes estão acessíveis

namespace UrbanFarming.Desktop
{
    public partial class FormProduto : Form
    {
        private readonly RequestAPI _requestAPI;

        public FormProduto()
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            _requestAPI = new RequestAPI(httpClient);
        }

        private async void buttonCadastrar_Click(object sender, EventArgs e)
        {
            var codigo = textBoxCodigo.Text;
            var nome = textBoxNome.Text;
            var valor = textBoxValor.Text;
            var descricao = textBoxDescricao.Text;
            var linkImagem = textBoxLinkImagem.Text;

            var produto = new Produtos
            {
                Codigo = codigo,
                Nome = nome,
                Valor = Convert.ToDecimal(valor),
                Descricao = descricao,
                LinkImagem = linkImagem
            };

            try
            {
                var response = await _requestAPI.EfetuarCadastradoProduto(produto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Produto cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show($"Erro ao cadastrar produto: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
