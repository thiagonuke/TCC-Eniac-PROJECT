using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;

namespace UrbanFarming.Desktop
{
    public partial class FormAdm : Form
    {
        private readonly RequestAPI _requestAPI;

        public FormAdm()
        {
            InitializeComponent();
            _requestAPI = new RequestAPI(new HttpClient());
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            var dados = new Login
            {
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Nome = txtNome.Text,
            };

            HttpResponseMessage response = await _requestAPI.EfetuarCadastrado(dados);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Usuário cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar usuário.");
            }
        }
    }
}
