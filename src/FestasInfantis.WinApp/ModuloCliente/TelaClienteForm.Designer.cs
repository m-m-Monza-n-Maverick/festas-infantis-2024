namespace FestasInfantis.WinApp.ModuloCliente
{
    partial class TelaClienteForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtId = new TextBox();
            txtTelefone = new TextBox();
            txtNome = new TextBox();
            txtCPF = new TextBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 41);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 70);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 128);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Telefone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 99);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 3;
            label4.Text = "CPF:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(84, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(55, 23);
            txtId.TabIndex = 13;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(84, 124);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(181, 23);
            txtTelefone.TabIndex = 2;
            txtTelefone.MaxLength = 11;
            txtTelefone.KeyPress += txtTelefone_KeyPress;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(84, 66);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(281, 23);
            txtNome.TabIndex = 0;
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(84, 95);
            txtCPF.Name = "txtCPF";
            txtCPF.Size = new Size(181, 23);
            txtCPF.TabIndex = 1;
            txtCPF.MaxLength = 11;
            txtCPF.KeyPress += txtCPF_KeyPress;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(12, 181);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(325, 181);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 4;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 212);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(txtCPF);
            Controls.Add(txtNome);
            Controls.Add(txtTelefone);
            Controls.Add(txtId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaClienteForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TelaClienteForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtId;
        private TextBox txtTelefone;
        private TextBox txtNome;
        private TextBox txtCPF;
        private Button btnCancelar;
        private Button btnGravar;
    }
}