namespace UrbanFarming.Desktop
{
    partial class FormProduto
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.TextBox textBoxCodigo;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelValor;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label labelLinkImagem;
        private System.Windows.Forms.TextBox textBoxLinkImagem;
        private System.Windows.Forms.Button buttonCadastrar;

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
            labelCodigo = new Label();
            textBoxCodigo = new TextBox();
            labelNome = new Label();
            textBoxNome = new TextBox();
            labelValor = new Label();
            textBoxValor = new TextBox();
            labelDescricao = new Label();
            textBoxDescricao = new TextBox();
            labelLinkImagem = new Label();
            textBoxLinkImagem = new TextBox();
            buttonCadastrar = new Button();
            SuspendLayout();
            // 
            // labelCodigo
            // 
            labelCodigo.AutoSize = true;
            labelCodigo.Location = new Point(20, 20);
            labelCodigo.Name = "labelCodigo";
            labelCodigo.Size = new Size(49, 15);
            labelCodigo.TabIndex = 0;
            labelCodigo.Text = "Código:";
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.Location = new Point(141, 20);
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(200, 23);
            textBoxCodigo.TabIndex = 1;
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Location = new Point(20, 60);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(43, 15);
            labelNome.TabIndex = 2;
            labelNome.Text = "Nome:";
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(141, 60);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(200, 23);
            textBoxNome.TabIndex = 3;
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Location = new Point(20, 103);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(36, 15);
            labelValor.TabIndex = 4;
            labelValor.Text = "Valor:";
            // 
            // textBoxValor
            // 
            textBoxValor.Location = new Point(141, 100);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(200, 23);
            textBoxValor.TabIndex = 5;
            // 
            // labelDescricao
            // 
            labelDescricao.AutoSize = true;
            labelDescricao.Location = new Point(20, 143);
            labelDescricao.Name = "labelDescricao";
            labelDescricao.Size = new Size(61, 15);
            labelDescricao.TabIndex = 6;
            labelDescricao.Text = "Descrição:";
            // 
            // textBoxDescricao
            // 
            textBoxDescricao.Location = new Point(141, 140);
            textBoxDescricao.Multiline = true;
            textBoxDescricao.Name = "textBoxDescricao";
            textBoxDescricao.Size = new Size(200, 60);
            textBoxDescricao.TabIndex = 7;
            // 
            // labelLinkImagem
            // 
            labelLinkImagem.AutoSize = true;
            labelLinkImagem.Location = new Point(20, 223);
            labelLinkImagem.Name = "labelLinkImagem";
            labelLinkImagem.Size = new Size(95, 15);
            labelLinkImagem.TabIndex = 8;
            labelLinkImagem.Text = "Link da Imagem:";
            // 
            // textBoxLinkImagem
            // 
            textBoxLinkImagem.Location = new Point(141, 220);
            textBoxLinkImagem.Name = "textBoxLinkImagem";
            textBoxLinkImagem.Size = new Size(200, 23);
            textBoxLinkImagem.TabIndex = 9;
            // 
            // buttonCadastrar
            // 
            buttonCadastrar.Location = new Point(95, 266);
            buttonCadastrar.Name = "buttonCadastrar";
            buttonCadastrar.Size = new Size(200, 30);
            buttonCadastrar.TabIndex = 10;
            buttonCadastrar.Text = "Cadastrar Produto";
            buttonCadastrar.UseVisualStyleBackColor = true;
            buttonCadastrar.Click += buttonCadastrar_Click;
            // 
            // FormProduto
            // 
            BackColor = Color.Green;
            ClientSize = new Size(391, 320);
            Controls.Add(labelCodigo);
            Controls.Add(textBoxCodigo);
            Controls.Add(labelNome);
            Controls.Add(textBoxNome);
            Controls.Add(labelValor);
            Controls.Add(textBoxValor);
            Controls.Add(labelDescricao);
            Controls.Add(textBoxDescricao);
            Controls.Add(labelLinkImagem);
            Controls.Add(textBoxLinkImagem);
            Controls.Add(buttonCadastrar);
            Name = "FormProduto";
            Text = "Cadastrar Produto";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
