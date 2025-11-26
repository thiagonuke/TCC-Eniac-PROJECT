using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UrbanFarming.Domain.Classes;

namespace UrbanFarmingDesktop.UI
{
    public partial class FormItensPedido : Form
    {
        public FormItensPedido(List<ItensPedido> itens)
        {
            InitializeComponent();
            LoadItems(itens);
        }

        private void LoadItems(List<ItensPedido> itens)
        {
            if (itens == null || !itens.Any())
            {
                MessageBox.Show("Nenhum item encontrado para este pedido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridViewItens.DataSource = itens.Select(i => new
            {
                i.NomeProduto,
                i.CodigoProduto,
                i.Quantidade,
                ValorUnitario = i.ValorUnitario.ToString("C2"), 
                Total = (i.Quantidade * i.ValorUnitario).ToString("C2")
            }).ToList();

            dataGridViewItens.Columns["NomeProduto"].HeaderText = "Nome do Produto";
            dataGridViewItens.Columns["CodigoProduto"].HeaderText = "Código do Produto";
            dataGridViewItens.Columns["Quantidade"].HeaderText = "Quantidade";
            dataGridViewItens.Columns["ValorUnitario"].HeaderText = "Valor Unitário";
            dataGridViewItens.Columns["Total"].HeaderText = "Total";
        }
    }
}
