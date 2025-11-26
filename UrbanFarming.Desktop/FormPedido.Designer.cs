namespace UrbanFarmingDesktop.UI
{
    partial class FormPedido
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxProdutos;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.DataGridView dataGridViewItens;
        private System.Windows.Forms.Button buttonFinalizarPedido;
        private System.Windows.Forms.Label labelValorTotal;

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
            comboBoxProdutos = new ComboBox();
            textBoxQuantidade = new TextBox();
            buttonAdicionar = new Button();
            dataGridViewItens = new DataGridView();
            buttonFinalizarPedido = new Button();
            labelValorTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItens).BeginInit();
            SuspendLayout();
            // 
            // comboBoxProdutos
            // 
            comboBoxProdutos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProdutos.FormattingEnabled = true;
            comboBoxProdutos.Location = new Point(12, 12);
            comboBoxProdutos.Name = "comboBoxProdutos";
            comboBoxProdutos.Size = new Size(200, 23);
            comboBoxProdutos.TabIndex = 0;
            // 
            // textBoxQuantidade
            // 
            textBoxQuantidade.Location = new Point(230, 12);
            textBoxQuantidade.Name = "textBoxQuantidade";
            textBoxQuantidade.Size = new Size(100, 23);
            textBoxQuantidade.TabIndex = 1;
            // 
            // buttonAdicionar
            // 
            buttonAdicionar.Location = new Point(340, 10);
            buttonAdicionar.Name = "buttonAdicionar";
            buttonAdicionar.Size = new Size(75, 25);
            buttonAdicionar.TabIndex = 2;
            buttonAdicionar.Text = "Adicionar";
            buttonAdicionar.UseVisualStyleBackColor = true;
            buttonAdicionar.Click += buttonAdicionar_Click;
            // 
            // dataGridViewItens
            // 
            dataGridViewItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItens.Location = new Point(12, 50);
            dataGridViewItens.Name = "dataGridViewItens";
            dataGridViewItens.ReadOnly = true;
            dataGridViewItens.Size = new Size(760, 300);
            dataGridViewItens.TabIndex = 3;
            // 
            // buttonFinalizarPedido
            // 
            buttonFinalizarPedido.Location = new Point(12, 370);
            buttonFinalizarPedido.Name = "buttonFinalizarPedido";
            buttonFinalizarPedido.Size = new Size(200, 30);
            buttonFinalizarPedido.TabIndex = 4;
            buttonFinalizarPedido.Text = "Finalizar Pedido";
            buttonFinalizarPedido.UseVisualStyleBackColor = true;
            buttonFinalizarPedido.Click += buttonFinalizarPedido_Click;
            // 
            // labelValorTotal
            // 
            labelValorTotal.AutoSize = true;
            labelValorTotal.Location = new Point(230, 375);
            labelValorTotal.Name = "labelValorTotal";
            labelValorTotal.Size = new Size(84, 15);
            labelValorTotal.TabIndex = 5;
            labelValorTotal.Text = "Valor Total: R$ 0,00";
            // 
            // FormPedido
            // 
            BackColor = Color.Green;
            ClientSize = new Size(784, 461);
            Controls.Add(labelValorTotal);
            Controls.Add(buttonFinalizarPedido);
            Controls.Add(dataGridViewItens);
            Controls.Add(buttonAdicionar);
            Controls.Add(textBoxQuantidade);
            Controls.Add(comboBoxProdutos);
            Name = "FormPedido";
            Text = "Fazer Pedido";
            ((System.ComponentModel.ISupportInitialize)dataGridViewItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
