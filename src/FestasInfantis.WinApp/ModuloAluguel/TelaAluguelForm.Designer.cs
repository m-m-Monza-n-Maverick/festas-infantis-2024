namespace FestasInfantis.WinApp.ModuloAluguel
{
    partial class TelaAluguelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox2 = new GroupBox();
            cmbEstado = new ComboBox();
            txtNumero = new TextBox();
            label9 = new Label();
            txtBairro = new TextBox();
            label5 = new Label();
            txtRua = new TextBox();
            txtCidade = new TextBox();
            label8 = new Label();
            label6 = new Label();
            label7 = new Label();
            groupBox1 = new GroupBox();
            mskHoraFim = new MaskedTextBox();
            mskHoraInicio = new MaskedTextBox();
            label4 = new Label();
            label1 = new Label();
            dtpDataFesta = new DateTimePicker();
            label3 = new Label();
            tabPage2 = new TabPage();
            groupBox3 = new GroupBox();
            toolStrip1 = new ToolStrip();
            btnAdicionar = new ToolStripButton();
            btnCalcular = new ToolStripLabel();
            txtValorPendente = new TextBox();
            label17 = new Label();
            txtTemaComDesconto = new TextBox();
            label16 = new Label();
            txtValorEntrada = new TextBox();
            txtValorTema = new TextBox();
            txtPercentDesconto = new TextBox();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label12 = new Label();
            cmbPercentEntrada = new ComboBox();
            label11 = new Label();
            cmbTema = new ComboBox();
            label10 = new Label();
            cmbClientes = new ComboBox();
            txtId = new TextBox();
            label2 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox3.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 59);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(456, 343);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(448, 315);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dados da Festa";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbEstado);
            groupBox2.Controls.Add(txtNumero);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(txtBairro);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtRua);
            groupBox2.Controls.Add(txtCidade);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label7);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(20, 156);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(407, 142);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dados do Endereço:";
            // 
            // cmbEstado
            // 
            cmbEstado.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.Location = new Point(320, 40);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(81, 23);
            cmbEstado.TabIndex = 4;
            cmbEstado.KeyPress += cmbEstado_KeyPress;
            // 
            // txtNumero
            // 
            txtNumero.Font = new Font("Segoe UI", 9F);
            txtNumero.Location = new Point(320, 98);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(81, 23);
            txtNumero.TabIndex = 7;
            txtNumero.TextAlign = HorizontalAlignment.Center;
            txtNumero.KeyPress += txtNumero_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F);
            label9.Location = new Point(260, 101);
            label9.Name = "label9";
            label9.Size = new Size(54, 15);
            label9.TabIndex = 11;
            label9.Text = "Número:";
            // 
            // txtBairro
            // 
            txtBairro.Font = new Font("Segoe UI", 9F);
            txtBairro.Location = new Point(59, 98);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(187, 23);
            txtBairro.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(14, 101);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 9;
            label5.Text = "Bairro:";
            // 
            // txtRua
            // 
            txtRua.Font = new Font("Segoe UI", 9F);
            txtRua.Location = new Point(59, 69);
            txtRua.Name = "txtRua";
            txtRua.Size = new Size(342, 23);
            txtRua.TabIndex = 5;
            // 
            // txtCidade
            // 
            txtCidade.Font = new Font("Segoe UI", 9F);
            txtCidade.Location = new Point(59, 40);
            txtCidade.Name = "txtCidade";
            txtCidade.Size = new Size(187, 23);
            txtCidade.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(269, 43);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 6;
            label8.Text = "Estado:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(25, 72);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 2;
            label6.Text = "Rua:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(8, 43);
            label7.Name = "label7";
            label7.Size = new Size(47, 15);
            label7.TabIndex = 1;
            label7.Text = "Cidade:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mskHoraFim);
            groupBox1.Controls.Add(mskHoraInicio);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtpDataFesta);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(20, 19);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(407, 125);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data e Hora:";
            // 
            // mskHoraFim
            // 
            mskHoraFim.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mskHoraFim.Location = new Point(134, 87);
            mskHoraFim.Mask = "00:00";
            mskHoraFim.Name = "mskHoraFim";
            mskHoraFim.Size = new Size(108, 23);
            mskHoraFim.TabIndex = 2;
            mskHoraFim.ValidatingType = typeof(DateTime);
            // 
            // mskHoraInicio
            // 
            mskHoraInicio.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mskHoraInicio.Location = new Point(134, 58);
            mskHoraInicio.Mask = "00:00";
            mskHoraInicio.Name = "mskHoraInicio";
            mskHoraInicio.Size = new Size(108, 23);
            mskHoraInicio.TabIndex = 1;
            mskHoraInicio.ValidatingType = typeof(DateTime);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(17, 91);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 3;
            label4.Text = "Horário de término:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(30, 62);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 2;
            label1.Text = "Horário de início:";
            // 
            // dtpDataFesta
            // 
            dtpDataFesta.Checked = false;
            dtpDataFesta.CustomFormat = "dd/MM/yyyy";
            dtpDataFesta.Font = new Font("Segoe UI", 9F);
            dtpDataFesta.Format = DateTimePickerFormat.Custom;
            dtpDataFesta.Location = new Point(134, 29);
            dtpDataFesta.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dtpDataFesta.MinDate = new DateTime(2024, 6, 5, 0, 0, 0, 0);
            dtpDataFesta.Name = "dtpDataFesta";
            dtpDataFesta.Size = new Size(108, 23);
            dtpDataFesta.TabIndex = 0;
            dtpDataFesta.ValueChanged += dtpDataFesta_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(50, 33);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 1;
            label3.Text = "Data da festa:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(cmbPercentEntrada);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(cmbTema);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(cmbClientes);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(448, 315);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Dados do Aluguel";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.BackgroundImageLayout = ImageLayout.Zoom;
            groupBox3.Controls.Add(toolStrip1);
            groupBox3.Controls.Add(txtValorPendente);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(txtTemaComDesconto);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(txtValorEntrada);
            groupBox3.Controls.Add(txtValorTema);
            groupBox3.Controls.Add(txtPercentDesconto);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label15);
            groupBox3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(21, 104);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(407, 182);
            groupBox3.TabIndex = 38;
            groupBox3.TabStop = false;
            groupBox3.Text = "Dados de Pagamento:";
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdicionar, btnCalcular });
            toolStrip1.Location = new Point(3, 23);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(401, 40);
            toolStrip1.TabIndex = 16;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAdicionar
            // 
            btnAdicionar.AutoSize = false;
            btnAdicionar.AutoToolTip = false;
            btnAdicionar.BackgroundImage = Properties.Resources.btnCalcularShow;
            btnAdicionar.BackgroundImageLayout = ImageLayout.Zoom;
            btnAdicionar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdicionar.Enabled = false;
            btnAdicionar.ImageTransparentColor = Color.Magenta;
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Padding = new Padding(5);
            btnAdicionar.Size = new Size(38, 38);
            btnAdicionar.Text = "Calcular";
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalcular.ForeColor = SystemColors.ControlDarkDark;
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(55, 37);
            btnCalcular.Text = "Calcular";
            btnCalcular.Click += btnCalcular_Click;
            // 
            // txtValorPendente
            // 
            txtValorPendente.Enabled = false;
            txtValorPendente.Font = new Font("Segoe UI", 9F);
            txtValorPendente.Location = new Point(314, 136);
            txtValorPendente.Name = "txtValorPendente";
            txtValorPendente.Size = new Size(81, 23);
            txtValorPendente.TabIndex = 15;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F);
            label17.Location = new Point(219, 139);
            label17.Name = "label17";
            label17.Size = new Size(89, 15);
            label17.TabIndex = 14;
            label17.Text = "Valor pendente:";
            // 
            // txtTemaComDesconto
            // 
            txtTemaComDesconto.Enabled = false;
            txtTemaComDesconto.Font = new Font("Segoe UI", 9F);
            txtTemaComDesconto.Location = new Point(314, 107);
            txtTemaComDesconto.Name = "txtTemaComDesconto";
            txtTemaComDesconto.Size = new Size(81, 23);
            txtTemaComDesconto.TabIndex = 13;
            // 
            // label16
            // 
            label16.AllowDrop = true;
            label16.Font = new Font("Segoe UI", 9F);
            label16.Location = new Point(216, 95);
            label16.Name = "label16";
            label16.Size = new Size(97, 35);
            label16.TabIndex = 12;
            label16.Text = "Valor do tema com desconto:";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtValorEntrada
            // 
            txtValorEntrada.Enabled = false;
            txtValorEntrada.Font = new Font("Segoe UI", 9F);
            txtValorEntrada.Location = new Point(105, 136);
            txtValorEntrada.Name = "txtValorEntrada";
            txtValorEntrada.Size = new Size(81, 23);
            txtValorEntrada.TabIndex = 11;
            // 
            // txtValorTema
            // 
            txtValorTema.Enabled = false;
            txtValorTema.Font = new Font("Segoe UI", 9F);
            txtValorTema.Location = new Point(105, 107);
            txtValorTema.Name = "txtValorTema";
            txtValorTema.Size = new Size(81, 23);
            txtValorTema.TabIndex = 10;
            // 
            // txtPercentDesconto
            // 
            txtPercentDesconto.Enabled = false;
            txtPercentDesconto.Font = new Font("Segoe UI", 9F);
            txtPercentDesconto.Location = new Point(105, 78);
            txtPercentDesconto.Name = "txtPercentDesconto";
            txtPercentDesconto.Size = new Size(50, 23);
            txtPercentDesconto.TabIndex = 9;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F);
            label13.Location = new Point(19, 139);
            label13.Name = "label13";
            label13.Size = new Size(80, 15);
            label13.TabIndex = 3;
            label13.Text = "Valor do sinal:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F);
            label14.Location = new Point(16, 110);
            label14.Name = "label14";
            label14.Size = new Size(83, 15);
            label14.TabIndex = 2;
            label14.Text = "Valor do tema:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F);
            label15.Location = new Point(11, 81);
            label15.Name = "label15";
            label15.Size = new Size(88, 15);
            label15.TabIndex = 1;
            label15.Text = "% de desconto:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F);
            label12.Location = new Point(23, 62);
            label12.Name = "label12";
            label12.Size = new Size(35, 15);
            label12.TabIndex = 37;
            label12.Text = "Sinal:";
            // 
            // cmbPercentEntrada
            // 
            cmbPercentEntrada.FormattingEnabled = true;
            cmbPercentEntrada.Location = new Point(64, 59);
            cmbPercentEntrada.Name = "cmbPercentEntrada";
            cmbPercentEntrada.Size = new Size(149, 23);
            cmbPercentEntrada.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F);
            label11.Location = new Point(240, 34);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 35;
            label11.Text = "Tema:";
            // 
            // cmbTema
            // 
            cmbTema.FormattingEnabled = true;
            cmbTema.Location = new Point(284, 30);
            cmbTema.Name = "cmbTema";
            cmbTema.Size = new Size(149, 23);
            cmbTema.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F);
            label10.Location = new Point(11, 34);
            label10.Name = "label10";
            label10.Size = new Size(47, 15);
            label10.TabIndex = 33;
            label10.Text = "Cliente:";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(64, 30);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(149, 23);
            cmbClientes.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(41, 20);
            txtId.Name = "txtId";
            txtId.Size = new Size(66, 23);
            txtId.TabIndex = 2;
            txtId.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 24);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 0;
            label2.Text = "Id:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(393, 418);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 9;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(12, 418);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 447);
            Controls.Add(btnGravar);
            Controls.Add(txtId);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaAluguelForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Aluguel";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox txtId;
        private Label label3;
        private Label label2;
        private TabPage tabPage2;
        private Button btnGravar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private DateTimePicker dtpDataFesta;
        private GroupBox groupBox2;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label1;
        private TextBox txtCidade;
        private Label label8;
        private TextBox txtNumero;
        private Label label9;
        private TextBox txtBairro;
        private Label label5;
        private TextBox txtRua;
        private Label label12;
        private ComboBox cmbPercentEntrada;
        private Label label11;
        private ComboBox cmbTema;
        private Label label10;
        private ComboBox cmbClientes;
        private GroupBox groupBox3;
        private Label label13;
        private Label label14;
        private Label label15;
        private TextBox txtValorPendente;
        private Label label17;
        private TextBox txtTemaComDesconto;
        private Label label16;
        private TextBox txtValorEntrada;
        private TextBox txtValorTema;
        private TextBox txtPercentDesconto;
        private ComboBox cmbEstado;
        private MaskedTextBox mskHoraInicio;
        private MaskedTextBox mskHoraFim;
        private ToolStrip toolStrip1;
        private ToolStripButton btnAdicionar;
        private ToolStripLabel btnCalcular;
    }
}