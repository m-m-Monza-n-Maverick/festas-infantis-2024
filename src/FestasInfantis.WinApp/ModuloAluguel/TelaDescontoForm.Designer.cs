namespace FestasInfantis.WinApp.ModuloAluguel
{
    partial class TelaDescontoForm
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
            groupBox1 = new GroupBox();
            txtPorcentMax = new NumericUpDown();
            label1 = new Label();
            txtPorcentPorAluguel = new NumericUpDown();
            label3 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPorcentMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPorcentPorAluguel).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPorcentMax);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPorcentPorAluguel);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(407, 128);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Porcentagem de Desconto:";
            // 
            // txtPorcentMax
            // 
            txtPorcentMax.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPorcentMax.Location = new Point(233, 73);
            txtPorcentMax.Name = "txtPorcentMax";
            txtPorcentMax.Size = new Size(53, 23);
            txtPorcentMax.TabIndex = 7;
            txtPorcentMax.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(74, 77);
            label1.Name = "label1";
            label1.Size = new Size(134, 15);
            label1.TabIndex = 6;
            label1.Text = "Máxima % de desconto:";
            // 
            // txtPorcentPorAluguel
            // 
            txtPorcentPorAluguel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPorcentPorAluguel.Location = new Point(233, 40);
            txtPorcentPorAluguel.Name = "txtPorcentPorAluguel";
            txtPorcentPorAluguel.Size = new Size(53, 23);
            txtPorcentPorAluguel.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(72, 44);
            label3.Name = "label3";
            label3.Size = new Size(136, 15);
            label3.TabIndex = 1;
            label3.Text = "% Desconto por aluguel:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(345, 163);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(12, 163);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaDescontoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 198);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaDescontoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuração de Descontos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPorcentMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPorcentPorAluguel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private NumericUpDown txtPorcentPorAluguel;
        private NumericUpDown txtPorcentMax;
        private Label label1;
        private Button btnGravar;
        private Button btnCancelar;
    }
}