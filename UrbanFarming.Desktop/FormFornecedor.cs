using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request; 

namespace UrbanFarmingDesktop.UI
{
    public partial class FormFornecedor : Form
    {
        private readonly RequestAPI _requestAPI;

        public FormFornecedor()
        {
            InitializeComponent();
            _requestAPI = new RequestAPI(new HttpClient()); 
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var isJuridica = radioButtonJuridica.Checked;
            campoCNPJ.Visible = isJuridica;
            campoCPF.Visible = !isJuridica;
        }

        private void inputCNPJ_Leave(object sender, EventArgs e)
        {
            var cnpj = inputCNPJ.Text.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
            if (cnpj.Length == 14)
            {
                inputRazaoSocial.Text = "Nome da Razão Social"; 
                inputNomeFantasia.Text = "Nome Fantasia"; 
            }
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            string cnpjLimpo = Regex.Replace(inputCNPJ.Text, @"[^\d]", "");
            string cpfLimpo = Regex.Replace(inputCPF.Text, @"[^\d]", "");

            if (radioButtonJuridica.Checked && cnpjLimpo.Length != 14)
            {
                MessageBox.Show("CNPJ inválido. Por favor, insira um CNPJ válido com 14 dígitos.");
                return;
            }

            if (radioButtonFisica.Checked && cpfLimpo.Length != 11)
            {
                MessageBox.Show("CPF inválido. Por favor, insira um CPF válido com 11 dígitos.");
                return;
            }

            var fornecedor = new Fornecedores
            {
                Codigo = 0,
                RazaoSocial = radioButtonJuridica.Checked ? inputRazaoSocial.Text.Trim() : null,
                NomeFantasia = radioButtonJuridica.Checked ? inputNomeFantasia.Text.Trim() : null,
                CNPJ = radioButtonJuridica.Checked ? cnpjLimpo : null, 
                PaisOrigem = inputPaisOrigem.Text.Trim(),
                Email = inputEmail.Text.Trim(),
                EnquadramentoEstadual = radioButtonJuridica.Checked ? "Exemplo de Enquadramento" : null,
                RamoAtividade = radioButtonJuridica.Checked ? "Exemplo de Ramo" : null,
                PessoaJuridica = radioButtonJuridica.Checked,
                PessoaFisica = radioButtonFisica.Checked,
            };

            var response = await _requestAPI.EfetuarCadastradoFornecedor(fornecedor);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cadastro realizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar fornecedor. Tente novamente.");
            }
        }
    }
}
