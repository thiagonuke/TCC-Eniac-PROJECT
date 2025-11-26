using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrbanFarming.Desktop;
using UrbanFarming.Domain.Classes; // Certifique-se de que a classe Login está acessível
using UrbanFarmingWeb.UI.Request; // Certifique-se de que esta referência está correta

namespace UrbanFarmingDesktop.UI
{
    public partial class Login : Form
    {
        private readonly RequestAPI _requestAPI;

        public Login()
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            _requestAPI = new RequestAPI(httpClient);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (!string.IsNullOrWhiteSpace(usuario) && !string.IsNullOrWhiteSpace(senha))
            {
                try
                {
                    var loginResponse = await _requestAPI.EfetuarLogin(usuario, senha);

                    if (loginResponse != null && loginResponse.Id != 0)
                    {
                        SessaoUsuario.UsuarioLogado = loginResponse;

                        FormMenu formMenu = new FormMenu();
                        formMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao efetuar login: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Por favor, preencha os campos de usuário e senha.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormAdm formAdm = new FormAdm();
            formAdm.Text = "Controle de Acesso";
            formAdm.Show();
        }
    }
}