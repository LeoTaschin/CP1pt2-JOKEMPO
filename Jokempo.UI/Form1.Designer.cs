namespace Jokempo.UI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnPedra;
        private System.Windows.Forms.Button btnPapel;
        private System.Windows.Forms.Button btnTesoura;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblInstrucoes;
        private System.Windows.Forms.Label lblJogadaOponente;
        private System.Windows.Forms.Label lblEstatisticasGlobais;
        private System.Windows.Forms.TextBox txtP1;
        private System.Windows.Forms.TextBox txtP2;
        private System.Windows.Forms.Button btnSetP1;
        private System.Windows.Forms.Button btnSetP2;
        private System.Windows.Forms.ComboBox cmbModoJogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnPedra = new System.Windows.Forms.Button();
            this.btnPapel = new System.Windows.Forms.Button();
            this.btnTesoura = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblInstrucoes = new System.Windows.Forms.Label();
            this.lblJogadaOponente = new System.Windows.Forms.Label();
            this.lblEstatisticasGlobais = new System.Windows.Forms.Label();
            this.txtP1 = new System.Windows.Forms.TextBox();
            this.txtP2 = new System.Windows.Forms.TextBox();
            this.btnSetP1 = new System.Windows.Forms.Button();
            this.btnSetP2 = new System.Windows.Forms.Button();
            this.cmbModoJogo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();

            // Configuração do Form
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(550, 600);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Name = "Form1";
            this.Text = "Jokempo Ultimate - Eng. Software FIAP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Jogador 1 (Top Left)
            this.txtP1.Location = new System.Drawing.Point(20, 20);
            this.txtP1.Size = new System.Drawing.Size(120, 25);
            this.txtP1.Text = "Jogador 1";
            this.txtP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.txtP1.ForeColor = System.Drawing.Color.White;
            
            this.btnSetP1.Location = new System.Drawing.Point(150, 19);
            this.btnSetP1.Size = new System.Drawing.Size(70, 27);
            this.btnSetP1.Text = "Set P1";
            this.btnSetP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetP1.Click += new System.EventHandler(this.btnSetP1_Click);

            // Jogador 2 (Top Right)
            this.txtP2.Location = new System.Drawing.Point(320, 20);
            this.txtP2.Size = new System.Drawing.Size(120, 25);
            this.txtP2.Text = "Jogador 2";
            this.txtP2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.txtP2.ForeColor = System.Drawing.Color.White;

            this.btnSetP2.Location = new System.Drawing.Point(450, 19);
            this.btnSetP2.Size = new System.Drawing.Size(70, 27);
            this.btnSetP2.Text = "Set P2";
            this.btnSetP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetP2.Click += new System.EventHandler(this.btnSetP2_Click);

            // Modo de Jogo Selector
            this.cmbModoJogo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModoJogo.Items.AddRange(new object[] { "1. Clássico vs PC", "2. Multiplayer Local (P1 vs P2)", "3. Round 6 (Menos Um) vs PC" });
            this.cmbModoJogo.Location = new System.Drawing.Point(20, 70);
            this.cmbModoJogo.Size = new System.Drawing.Size(500, 25);
            this.cmbModoJogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.cmbModoJogo.ForeColor = System.Drawing.Color.Cyan;
            this.cmbModoJogo.SelectedIndexChanged += new System.EventHandler(this.cmbModoJogo_SelectedIndexChanged);

            // Instruções Dinâmicas
            this.lblInstrucoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInstrucoes.ForeColor = System.Drawing.Color.Yellow;
            this.lblInstrucoes.Location = new System.Drawing.Point(20, 120);
            this.lblInstrucoes.Size = new System.Drawing.Size(500, 30);
            this.lblInstrucoes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Painel Central (Botões)
            this.btnPedra.Location = new System.Drawing.Point(65, 170);
            this.btnPedra.Size = new System.Drawing.Size(120, 60);
            this.btnPedra.Text = "Pedra";
            this.btnPedra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPedra.Click += new System.EventHandler(this.btnPedra_Click);

            this.btnPapel.Location = new System.Drawing.Point(215, 170);
            this.btnPapel.Size = new System.Drawing.Size(120, 60);
            this.btnPapel.Text = "Papel";
            this.btnPapel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPapel.Click += new System.EventHandler(this.btnPapel_Click);

            this.btnTesoura.Location = new System.Drawing.Point(365, 170);
            this.btnTesoura.Size = new System.Drawing.Size(120, 60);
            this.btnTesoura.Text = "Tesoura";
            this.btnTesoura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTesoura.Click += new System.EventHandler(this.btnTesoura_Click);

            // Jogadas e Resultado
            this.lblJogadaOponente.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblJogadaOponente.ForeColor = System.Drawing.Color.White;
            this.lblJogadaOponente.Location = new System.Drawing.Point(20, 250);
            this.lblJogadaOponente.Size = new System.Drawing.Size(500, 50);
            this.lblJogadaOponente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(20, 310);
            this.lblResultado.Size = new System.Drawing.Size(500, 40);
            this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Estatísticas Globais
            this.lblEstatisticasGlobais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.lblEstatisticasGlobais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEstatisticasGlobais.Location = new System.Drawing.Point(20, 380);
            this.lblEstatisticasGlobais.Size = new System.Drawing.Size(500, 180);
            this.lblEstatisticasGlobais.Padding = new System.Windows.Forms.Padding(10);

            // Add Controls
            this.Controls.Add(this.txtP1); this.Controls.Add(this.btnSetP1);
            this.Controls.Add(this.txtP2); this.Controls.Add(this.btnSetP2);
            this.Controls.Add(this.cmbModoJogo);
            this.Controls.Add(this.lblInstrucoes);
            this.Controls.Add(this.btnPedra); this.Controls.Add(this.btnPapel); this.Controls.Add(this.btnTesoura);
            this.Controls.Add(this.lblJogadaOponente);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblEstatisticasGlobais);
            this.ResumeLayout(false);
        }
    }
}