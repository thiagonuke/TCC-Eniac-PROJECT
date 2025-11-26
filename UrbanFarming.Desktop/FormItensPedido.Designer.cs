namespace UrbanFarmingDesktop.UI
{
    partial class FormItensPedido
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewItens;

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
            dataGridViewItens = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItens).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewItens
            // 
            dataGridViewItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItens.Location = new System.Drawing.Point(12, 12);
            dataGridViewItens.Name = "dataGridViewItens";
            dataGridViewItens.ReadOnly = true;
            dataGridViewItens.AllowUserToAddRows = false; // Prevent user from adding rows
            dataGridViewItens.AllowUserToDeleteRows = false; // Prevent user from deleting rows
            dataGridViewItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Make columns fill space
            dataGridViewItens.Size = new System.Drawing.Size(760, 400);
            dataGridViewItens.TabIndex = 0;
            // 
            // FormItensPedido
            // 
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(dataGridViewItens);
            Name = "FormItensPedido";
            Text = "Itens do Pedido";
            ((System.ComponentModel.ISupportInitialize)dataGridViewItens).EndInit();
            ResumeLayout(false);
        }
    }
}
