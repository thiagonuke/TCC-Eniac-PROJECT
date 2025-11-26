using System;
using System.Windows.Forms;
using UrbanFarmingDesktop.UI;
using static System.Windows.Forms.DataFormats;

namespace UrbanFarming.Desktop
{
    public partial class FormMenu : Form
    {
        private Button buttonAdm;
        private Button buttonDelProdutos;

        public FormMenu()
        {
            InitializeComponent();

            if (SessaoUsuario.UsuarioLogado != null && SessaoUsuario.UsuarioLogado.Administrador)
            {
                //buttonAdm = new Button
                //{
                //    Location = new System.Drawing.Point(88, 302),
                //    Name = "buttonAdm",
                //    Size = new System.Drawing.Size(175, 47),
                //    Text = "Controle de Acesso",
                //    UseVisualStyleBackColor = true
                //};
                //buttonAdm.Click += buttonAdm_Click;
                //Controls.Add(buttonAdm);

                ClientSize = new System.Drawing.Size(350, 450);

                buttonProduto.Visible = true;

                btnDeletarProd.Click += buttonDelProdutos_Click;

                btnDeletarProd.Visible = true;

            }
        }

        private void buttonProduto_Click(object sender, EventArgs e)
        {
            FormProduto formProduto = new FormProduto();
            formProduto.Show();
        }

        private void buttonPedido_Click(object sender, EventArgs e)
        {
            FormPedido formPedido = new FormPedido();
            formPedido.Show();
        }

        private void buttonListaPedidos_Click(object sender, EventArgs e)
        {
            FormListaPedidos formListaPedidos = new FormListaPedidos();
            formListaPedidos.Show();
        }

        private void buttonFornecedor_Click(object sender, EventArgs e)
        {
            FormFornecedor formFornecedor = new FormFornecedor();
            formFornecedor.Show();
        }

        private void buttonDelProdutos_Click(object sender, EventArgs e)
        {
            FormDelProdutos formDelProdutos = new FormDelProdutos();
            formDelProdutos.Text = "Deletar Produtos";
            formDelProdutos.Show();
        }
    }
}
