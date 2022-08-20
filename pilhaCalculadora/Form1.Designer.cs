namespace pilhaCalculadora
{
    partial class frmCalculadora
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtVisor = new System.Windows.Forms.TextBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.lbSequencias = new System.Windows.Forms.Label();
            this.btnExpo = new System.Windows.Forms.Button();
            this.btnDivisao = new System.Windows.Forms.Button();
            this.btnMultiplicacao = new System.Windows.Forms.Button();
            this.btnSubtracao = new System.Windows.Forms.Button();
            this.btnSete = new System.Windows.Forms.Button();
            this.btnOito = new System.Windows.Forms.Button();
            this.btnNove = new System.Windows.Forms.Button();
            this.btnSoma = new System.Windows.Forms.Button();
            this.btnQuatro = new System.Windows.Forms.Button();
            this.btnCinco = new System.Windows.Forms.Button();
            this.btnSeis = new System.Windows.Forms.Button();
            this.btnDecimal = new System.Windows.Forms.Button();
            this.btnUm = new System.Windows.Forms.Button();
            this.btnDois = new System.Windows.Forms.Button();
            this.btnTres = new System.Windows.Forms.Button();
            this.btnFechaParenteses = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnIgual = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAbreParenteses = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtVisor
            // 
            this.txtVisor.Location = new System.Drawing.Point(13, 13);
            this.txtVisor.Margin = new System.Windows.Forms.Padding(4);
            this.txtVisor.Name = "txtVisor";
            this.txtVisor.Size = new System.Drawing.Size(401, 26);
            this.txtVisor.TabIndex = 0;
            this.txtVisor.DoubleClick += new System.EventHandler(this.txtVisor_DoubleClick);
            this.txtVisor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVisor_KeyDown);
            this.txtVisor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVisor_KeyPress);
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(13, 47);
            this.txtResultado.Margin = new System.Windows.Forms.Padding(4);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(401, 26);
            this.txtResultado.TabIndex = 1;
            // 
            // lbSequencias
            // 
            this.lbSequencias.AutoSize = true;
            this.lbSequencias.Location = new System.Drawing.Point(12, 88);
            this.lbSequencias.Name = "lbSequencias";
            this.lbSequencias.Size = new System.Drawing.Size(107, 18);
            this.lbSequencias.TabIndex = 2;
            this.lbSequencias.Text = "Infixa/Pósfixa: ";
            // 
            // btnExpo
            // 
            this.btnExpo.BackColor = System.Drawing.SystemColors.Menu;
            this.btnExpo.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnExpo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpo.Location = new System.Drawing.Point(14, 130);
            this.btnExpo.Name = "btnExpo";
            this.btnExpo.Size = new System.Drawing.Size(85, 45);
            this.btnExpo.TabIndex = 3;
            this.btnExpo.Text = "^";
            this.btnExpo.UseVisualStyleBackColor = false;
            this.btnExpo.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnDivisao
            // 
            this.btnDivisao.BackColor = System.Drawing.SystemColors.Menu;
            this.btnDivisao.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDivisao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivisao.Location = new System.Drawing.Point(117, 130);
            this.btnDivisao.Name = "btnDivisao";
            this.btnDivisao.Size = new System.Drawing.Size(85, 45);
            this.btnDivisao.TabIndex = 4;
            this.btnDivisao.Text = "/";
            this.btnDivisao.UseVisualStyleBackColor = false;
            this.btnDivisao.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnMultiplicacao
            // 
            this.btnMultiplicacao.BackColor = System.Drawing.SystemColors.Menu;
            this.btnMultiplicacao.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnMultiplicacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiplicacao.Location = new System.Drawing.Point(220, 130);
            this.btnMultiplicacao.Name = "btnMultiplicacao";
            this.btnMultiplicacao.Size = new System.Drawing.Size(85, 45);
            this.btnMultiplicacao.TabIndex = 5;
            this.btnMultiplicacao.Text = "*";
            this.btnMultiplicacao.UseVisualStyleBackColor = false;
            this.btnMultiplicacao.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnSubtracao
            // 
            this.btnSubtracao.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSubtracao.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSubtracao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubtracao.Location = new System.Drawing.Point(323, 130);
            this.btnSubtracao.Name = "btnSubtracao";
            this.btnSubtracao.Size = new System.Drawing.Size(85, 45);
            this.btnSubtracao.TabIndex = 6;
            this.btnSubtracao.Text = "-";
            this.btnSubtracao.UseVisualStyleBackColor = false;
            this.btnSubtracao.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnSete
            // 
            this.btnSete.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSete.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSete.Location = new System.Drawing.Point(14, 181);
            this.btnSete.Name = "btnSete";
            this.btnSete.Size = new System.Drawing.Size(85, 45);
            this.btnSete.TabIndex = 7;
            this.btnSete.Text = "7";
            this.btnSete.UseVisualStyleBackColor = false;
            this.btnSete.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnOito
            // 
            this.btnOito.BackColor = System.Drawing.SystemColors.Menu;
            this.btnOito.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOito.Location = new System.Drawing.Point(117, 181);
            this.btnOito.Name = "btnOito";
            this.btnOito.Size = new System.Drawing.Size(85, 45);
            this.btnOito.TabIndex = 8;
            this.btnOito.Text = "8";
            this.btnOito.UseVisualStyleBackColor = false;
            this.btnOito.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnNove
            // 
            this.btnNove.BackColor = System.Drawing.SystemColors.Menu;
            this.btnNove.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnNove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNove.Location = new System.Drawing.Point(220, 181);
            this.btnNove.Name = "btnNove";
            this.btnNove.Size = new System.Drawing.Size(85, 45);
            this.btnNove.TabIndex = 9;
            this.btnNove.Text = "9";
            this.btnNove.UseVisualStyleBackColor = false;
            this.btnNove.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnSoma
            // 
            this.btnSoma.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSoma.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSoma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoma.Location = new System.Drawing.Point(323, 181);
            this.btnSoma.Name = "btnSoma";
            this.btnSoma.Size = new System.Drawing.Size(85, 45);
            this.btnSoma.TabIndex = 10;
            this.btnSoma.Text = "+";
            this.btnSoma.UseVisualStyleBackColor = false;
            this.btnSoma.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnQuatro
            // 
            this.btnQuatro.BackColor = System.Drawing.SystemColors.Menu;
            this.btnQuatro.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnQuatro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuatro.Location = new System.Drawing.Point(14, 232);
            this.btnQuatro.Name = "btnQuatro";
            this.btnQuatro.Size = new System.Drawing.Size(85, 45);
            this.btnQuatro.TabIndex = 11;
            this.btnQuatro.Text = "4";
            this.btnQuatro.UseVisualStyleBackColor = false;
            this.btnQuatro.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnCinco
            // 
            this.btnCinco.BackColor = System.Drawing.SystemColors.Menu;
            this.btnCinco.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCinco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCinco.Location = new System.Drawing.Point(117, 232);
            this.btnCinco.Name = "btnCinco";
            this.btnCinco.Size = new System.Drawing.Size(85, 45);
            this.btnCinco.TabIndex = 12;
            this.btnCinco.Text = "5";
            this.btnCinco.UseVisualStyleBackColor = false;
            this.btnCinco.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnSeis
            // 
            this.btnSeis.BackColor = System.Drawing.SystemColors.Menu;
            this.btnSeis.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSeis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeis.Location = new System.Drawing.Point(220, 232);
            this.btnSeis.Name = "btnSeis";
            this.btnSeis.Size = new System.Drawing.Size(85, 45);
            this.btnSeis.TabIndex = 13;
            this.btnSeis.Text = "6";
            this.btnSeis.UseVisualStyleBackColor = false;
            this.btnSeis.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnDecimal
            // 
            this.btnDecimal.BackColor = System.Drawing.SystemColors.Menu;
            this.btnDecimal.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecimal.Location = new System.Drawing.Point(323, 232);
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.Size = new System.Drawing.Size(85, 45);
            this.btnDecimal.TabIndex = 14;
            this.btnDecimal.Text = ".";
            this.btnDecimal.UseVisualStyleBackColor = false;
            this.btnDecimal.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnUm
            // 
            this.btnUm.BackColor = System.Drawing.SystemColors.Menu;
            this.btnUm.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnUm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUm.Location = new System.Drawing.Point(14, 283);
            this.btnUm.Name = "btnUm";
            this.btnUm.Size = new System.Drawing.Size(85, 45);
            this.btnUm.TabIndex = 15;
            this.btnUm.Text = "1";
            this.btnUm.UseVisualStyleBackColor = false;
            this.btnUm.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnDois
            // 
            this.btnDois.BackColor = System.Drawing.SystemColors.Menu;
            this.btnDois.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDois.Location = new System.Drawing.Point(117, 283);
            this.btnDois.Name = "btnDois";
            this.btnDois.Size = new System.Drawing.Size(85, 45);
            this.btnDois.TabIndex = 16;
            this.btnDois.Text = "2";
            this.btnDois.UseVisualStyleBackColor = false;
            this.btnDois.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnTres
            // 
            this.btnTres.BackColor = System.Drawing.SystemColors.Menu;
            this.btnTres.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnTres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTres.Location = new System.Drawing.Point(220, 283);
            this.btnTres.Name = "btnTres";
            this.btnTres.Size = new System.Drawing.Size(85, 45);
            this.btnTres.TabIndex = 17;
            this.btnTres.Text = "3";
            this.btnTres.UseVisualStyleBackColor = false;
            this.btnTres.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnFechaParenteses
            // 
            this.btnFechaParenteses.BackColor = System.Drawing.SystemColors.Menu;
            this.btnFechaParenteses.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFechaParenteses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechaParenteses.Location = new System.Drawing.Point(323, 283);
            this.btnFechaParenteses.Name = "btnFechaParenteses";
            this.btnFechaParenteses.Size = new System.Drawing.Size(85, 45);
            this.btnFechaParenteses.TabIndex = 18;
            this.btnFechaParenteses.Text = ")";
            this.btnFechaParenteses.UseVisualStyleBackColor = false;
            this.btnFechaParenteses.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnZero
            // 
            this.btnZero.BackColor = System.Drawing.SystemColors.Menu;
            this.btnZero.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZero.Location = new System.Drawing.Point(14, 334);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(85, 45);
            this.btnZero.TabIndex = 19;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = false;
            this.btnZero.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // btnIgual
            // 
            this.btnIgual.BackColor = System.Drawing.SystemColors.Menu;
            this.btnIgual.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnIgual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIgual.Location = new System.Drawing.Point(117, 334);
            this.btnIgual.Name = "btnIgual";
            this.btnIgual.Size = new System.Drawing.Size(85, 45);
            this.btnIgual.TabIndex = 20;
            this.btnIgual.Text = "=";
            this.btnIgual.UseVisualStyleBackColor = false;
            this.btnIgual.Click += new System.EventHandler(this.btnIgual_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.SystemColors.Menu;
            this.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Location = new System.Drawing.Point(220, 334);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(85, 45);
            this.btnLimpar.TabIndex = 21;
            this.btnLimpar.Text = "C";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAbreParenteses
            // 
            this.btnAbreParenteses.BackColor = System.Drawing.SystemColors.Menu;
            this.btnAbreParenteses.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAbreParenteses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbreParenteses.Location = new System.Drawing.Point(323, 334);
            this.btnAbreParenteses.Name = "btnAbreParenteses";
            this.btnAbreParenteses.Size = new System.Drawing.Size(85, 45);
            this.btnAbreParenteses.TabIndex = 22;
            this.btnAbreParenteses.Text = "(";
            this.btnAbreParenteses.UseVisualStyleBackColor = false;
            this.btnAbreParenteses.Click += new System.EventHandler(this.btnExpo_Click_1);
            // 
            // frmCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(429, 398);
            this.Controls.Add(this.btnAbreParenteses);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnIgual);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnFechaParenteses);
            this.Controls.Add(this.btnTres);
            this.Controls.Add(this.btnDois);
            this.Controls.Add(this.btnUm);
            this.Controls.Add(this.btnDecimal);
            this.Controls.Add(this.btnSeis);
            this.Controls.Add(this.btnCinco);
            this.Controls.Add(this.btnQuatro);
            this.Controls.Add(this.btnSoma);
            this.Controls.Add(this.btnNove);
            this.Controls.Add(this.btnOito);
            this.Controls.Add(this.btnSete);
            this.Controls.Add(this.btnSubtracao);
            this.Controls.Add(this.btnMultiplicacao);
            this.Controls.Add(this.btnDivisao);
            this.Controls.Add(this.btnExpo);
            this.Controls.Add(this.lbSequencias);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.txtVisor);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(445, 437);
            this.MinimumSize = new System.Drawing.Size(445, 437);
            this.Name = "frmCalculadora";
            this.Text = "Calculadora";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVisor;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label lbSequencias;
        private System.Windows.Forms.Button btnExpo;
        private System.Windows.Forms.Button btnDivisao;
        private System.Windows.Forms.Button btnMultiplicacao;
        private System.Windows.Forms.Button btnSubtracao;
        private System.Windows.Forms.Button btnSete;
        private System.Windows.Forms.Button btnOito;
        private System.Windows.Forms.Button btnNove;
        private System.Windows.Forms.Button btnSoma;
        private System.Windows.Forms.Button btnQuatro;
        private System.Windows.Forms.Button btnCinco;
        private System.Windows.Forms.Button btnSeis;
        private System.Windows.Forms.Button btnDecimal;
        private System.Windows.Forms.Button btnUm;
        private System.Windows.Forms.Button btnDois;
        private System.Windows.Forms.Button btnTres;
        private System.Windows.Forms.Button btnFechaParenteses;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnIgual;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAbreParenteses;
    }
}

