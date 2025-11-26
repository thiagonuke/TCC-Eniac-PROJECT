namespace UrbanFarmingDesktop.UI
{
    partial class FormListaPedidos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;

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
            dataGridViewPedidos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.Location = new Point(12, 12);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ReadOnly = true;
            dataGridViewPedidos.Size = new Size(760, 400);
            dataGridViewPedidos.TabIndex = 0;
            // 
            // FormListaPedidos
            // 
            BackColor = Color.Green;
            ClientSize = new Size(784, 461);
            Controls.Add(dataGridViewPedidos);
            Name = "FormListaPedidos";
            Text = "Meus Pedidos";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            ResumeLayout(false);
        }
    }
}
