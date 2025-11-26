using System;
using System.Windows.Forms;

namespace UrbanFarmingDesktop.UI
{
    partial class FormFornecedor
    {
        private System.ComponentModel.IContainer components = null;
        private RadioButton radioButtonJuridica;
        private RadioButton radioButtonFisica;
        private GroupBox grupoTipoPessoa;
        private TextBox inputCodigo;
        private MaskedTextBox inputCNPJ;
        private TextBox inputRazaoSocial;
        private TextBox inputNomeFantasia;
        private MaskedTextBox inputCPF;
        private TextBox inputNome;
        private TextBox inputEmail;
        private MaskedTextBox inputTelefone;
        private TextBox inputEndereco;
        private MaskedTextBox inputCEP;
        private TextBox inputPaisOrigem;
        private Button btnCadastrar;
        private Panel campoCNPJ;
        private Panel campoCPF;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grupoTipoPessoa = new GroupBox();
            radioButtonJuridica = new RadioButton();
            radioButtonFisica = new RadioButton();
            inputCodigo = new TextBox();
            campoCNPJ = new Panel();
            inputCNPJ = new MaskedTextBox();
            inputRazaoSocial = new TextBox();
            inputNomeFantasia = new TextBox();
            campoCPF = new Panel();
            inputCPF = new MaskedTextBox();
            inputNome = new TextBox();
            inputEmail = new TextBox();
            inputTelefone = new MaskedTextBox();
            inputEndereco = new TextBox();
            inputCEP = new MaskedTextBox();
            inputPaisOrigem = new TextBox();
            btnCadastrar = new Button();
            grupoTipoPessoa.SuspendLayout();
            campoCNPJ.SuspendLayout();
            campoCPF.SuspendLayout();
            SuspendLayout();
            // 
            // grupoTipoPessoa
            // 
            grupoTipoPessoa.Controls.Add(radioButtonJuridica);
            grupoTipoPessoa.Controls.Add(radioButtonFisica);
            grupoTipoPessoa.Location = new Point(12, 12);
            grupoTipoPessoa.Name = "grupoTipoPessoa";
            grupoTipoPessoa.Size = new Size(350, 100);
            grupoTipoPessoa.TabIndex = 0;
            grupoTipoPessoa.TabStop = false;
            grupoTipoPessoa.Text = "Pessoa Jurídica ou Física";
            // 
            // radioButtonJuridica
            // 
            radioButtonJuridica.AutoSize = true;
            radioButtonJuridica.Location = new Point(6, 22);
            radioButtonJuridica.Name = "radioButtonJuridica";
            radioButtonJuridica.Size = new Size(142, 19);
            radioButtonJuridica.TabIndex = 1;
            radioButtonJuridica.TabStop = true;
            radioButtonJuridica.Text = "Pessoa Jurídica (CNPJ)";
            radioButtonJuridica.UseVisualStyleBackColor = true;
            radioButtonJuridica.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonFisica
            // 
            radioButtonFisica.AutoSize = true;
            radioButtonFisica.Location = new Point(6, 47);
            radioButtonFisica.Name = "radioButtonFisica";
            radioButtonFisica.Size = new Size(125, 19);
            radioButtonFisica.TabIndex = 2;
            radioButtonFisica.TabStop = true;
            radioButtonFisica.Text = "Pessoa Física (CPF)";
            radioButtonFisica.UseVisualStyleBackColor = true;
            radioButtonFisica.CheckedChanged += radioButton_CheckedChanged;
            // 
            // inputCodigo
            // 
            inputCodigo.Location = new Point(12, 118);
            inputCodigo.Name = "inputCodigo";
            inputCodigo.PlaceholderText = "Código";
            inputCodigo.Size = new Size(200, 23);
            inputCodigo.TabIndex = 3;
            // 
            // campoCNPJ
            // 
            campoCNPJ.Controls.Add(inputCNPJ);
            campoCNPJ.Controls.Add(inputRazaoSocial);
            campoCNPJ.Controls.Add(inputNomeFantasia);
            campoCNPJ.Location = new Point(12, 147);
            campoCNPJ.Name = "campoCNPJ";
            campoCNPJ.Size = new Size(350, 150);
            campoCNPJ.TabIndex = 4;
            campoCNPJ.Visible = false;
            // 
            // inputCNPJ
            // 
            inputCNPJ.Location = new Point(0, 0);
            inputCNPJ.Mask = "00.000.000/0000-00"; // Máscara de CNPJ
            inputCNPJ.Name = "inputCNPJ";
            inputCNPJ.Size = new Size(200, 23);
            inputCNPJ.TabIndex = 4;
            inputCNPJ.Leave += inputCNPJ_Leave;
            // 
            // inputRazaoSocial
            // 
            inputRazaoSocial.Location = new Point(0, 30);
            inputRazaoSocial.Name = "inputRazaoSocial";
            inputRazaoSocial.PlaceholderText = "Razão Social";
            inputRazaoSocial.Size = new Size(200, 23);
            inputRazaoSocial.TabIndex = 5;
            // 
            // inputNomeFantasia
            // 
            inputNomeFantasia.Location = new Point(0, 60);
            inputNomeFantasia.Name = "inputNomeFantasia";
            inputNomeFantasia.PlaceholderText = "Nome Fantasia";
            inputNomeFantasia.Size = new Size(200, 23);
            inputNomeFantasia.TabIndex = 6;
            // 
            // campoCPF
            // 
            campoCPF.Controls.Add(inputCPF);
            campoCPF.Controls.Add(inputNome);
            campoCPF.Location = new Point(12, 147);
            campoCPF.Name = "campoCPF";
            campoCPF.Size = new Size(350, 100);
            campoCPF.TabIndex = 5;
            campoCPF.Visible = false;
            // 
            // inputCPF
            // 
            inputCPF.Location = new Point(0, 0);
            inputCPF.Mask = "000.000.000-00"; // Máscara de CPF
            inputCPF.Name = "inputCPF";
            inputCPF.Size = new Size(200, 23);
            inputCPF.TabIndex = 7;
            // 
            // inputNome
            // 
            inputNome.Location = new Point(0, 30);
            inputNome.Name = "inputNome";
            inputNome.PlaceholderText = "Nome Completo";
            inputNome.Size = new Size(200, 23);
            inputNome.TabIndex = 8;
            // 
            // inputEmail
            // 
            inputEmail.Location = new Point(12, 253);
            inputEmail.Name = "inputEmail";
            inputEmail.PlaceholderText = "Email";
            inputEmail.Size = new Size(200, 23);
            inputEmail.TabIndex = 9;
            // 
            // inputTelefone
            // 
            inputTelefone.Location = new Point(12, 282);
            inputTelefone.Mask = "(99) 99999-9999"; // Máscara de Telefone
            inputTelefone.Name = "inputTelefone";
            inputTelefone.Size = new Size(200, 23);
            inputTelefone.TabIndex = 10;
            // 
            // inputEndereco
            // 
            inputEndereco.Location = new Point(12, 311);
            inputEndereco.Name = "inputEndereco";
            inputEndereco.PlaceholderText = "Endereço";
            inputEndereco.Size = new Size(200, 23);
            inputEndereco.TabIndex = 11;
            // 
            // inputCEP
            // 
            inputCEP.Location = new Point(12, 340);
            inputCEP.Mask = "00000-000"; // Máscara de CEP
            inputCEP.Name = "inputCEP";
            inputCEP.Size = new Size(200, 23);
            inputCEP.TabIndex = 12;
            // 
            // inputPaisOrigem
            // 
            inputPaisOrigem.Location = new Point(12, 369);
            inputPaisOrigem.Name = "inputPaisOrigem";
            inputPaisOrigem.PlaceholderText = "País de Origem";
            inputPaisOrigem.Size = new Size(200, 23);
            inputPaisOrigem.TabIndex = 13;
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(12, 398);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(200, 30);
            btnCadastrar.TabIndex = 14;
            btnCadastrar.Text = "Cadastrar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // FormFornecedor
            // 
            BackColor = Color.Green;
            ClientSize = new Size(702, 441);
            Controls.Add(grupoTipoPessoa);
            Controls.Add(inputCodigo);
            Controls.Add(campoCNPJ);
            Controls.Add(campoCPF);
            Controls.Add(inputEmail);
            Controls.Add(inputTelefone);
            Controls.Add(inputEndereco);
            Controls.Add(inputCEP);
            Controls.Add(inputPaisOrigem);
            Controls.Add(btnCadastrar);
            Name = "FormFornecedor";
            Text = "Cadastro de Fornecedor";
            grupoTipoPessoa.ResumeLayout(false);
            grupoTipoPessoa.PerformLayout();
            campoCNPJ.ResumeLayout(false);
            campoCNPJ.PerformLayout();
            campoCPF.ResumeLayout(false);
            campoCPF.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
