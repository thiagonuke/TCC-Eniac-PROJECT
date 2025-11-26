namespace UrbanFarming.Desktop
{
    partial class FormDelProdutos
    {
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Button btnDeletar;

        private void InitializeComponent()
        {
            dgvProdutos = new DataGridView();
            btnDeletar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(14, 14);
            dgvProdutos.Margin = new Padding(4, 3, 4, 3);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Size = new Size(887, 404);
            dgvProdutos.TabIndex = 0;
            // 
            // btnDeletar
            // 
            btnDeletar.Location = new Point(14, 438);
            btnDeletar.Margin = new Padding(4, 3, 4, 3);
            btnDeletar.Name = "btnDeletar";
            btnDeletar.Size = new Size(117, 35);
            btnDeletar.TabIndex = 1;
            btnDeletar.Text = "Deletar";
            btnDeletar.UseVisualStyleBackColor = true;
            btnDeletar.Click += btnDeletar_Click;
            // 
            // FormDelProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(915, 486);
            Controls.Add(btnDeletar);
            Controls.Add(dgvProdutos);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormDelProdutos";
            Text = "Deletar Produtos";
            Load += FormDelProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
        }
    }
}
