namespace FestasInfantis.WinApp.ModuloAluguel
{
    partial class TelaFiltroAlugueisForm
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
            rdbAlugueisConcluidos = new RadioButton();
            rdbAlugueisPendentes = new RadioButton();
            groupBox1 = new GroupBox();
            rdbTodosAlugueis = new RadioButton();
            btnGravar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // rdbAlugueisConcluidos
            // 
            rdbAlugueisConcluidos.AutoSize = true;
            rdbAlugueisConcluidos.Font = new Font("Segoe UI", 9F);
            rdbAlugueisConcluidos.Location = new Point(32, 91);
            rdbAlugueisConcluidos.Name = "rdbAlugueisConcluidos";
            rdbAlugueisConcluidos.Size = new Size(132, 19);
            rdbAlugueisConcluidos.TabIndex = 2;
            rdbAlugueisConcluidos.TabStop = true;
            rdbAlugueisConcluidos.Text = "Alugueis concluídos";
            rdbAlugueisConcluidos.UseVisualStyleBackColor = true;
            // 
            // rdbAlugueisPendentes
            // 
            rdbAlugueisPendentes.AutoSize = true;
            rdbAlugueisPendentes.Font = new Font("Segoe UI", 9F);
            rdbAlugueisPendentes.Location = new Point(32, 61);
            rdbAlugueisPendentes.Name = "rdbAlugueisPendentes";
            rdbAlugueisPendentes.Size = new Size(128, 19);
            rdbAlugueisPendentes.TabIndex = 1;
            rdbAlugueisPendentes.TabStop = true;
            rdbAlugueisPendentes.Text = "Aluguéis em aberto";
            rdbAlugueisPendentes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdbAlugueisConcluidos);
            groupBox1.Controls.Add(rdbAlugueisPendentes);
            groupBox1.Controls.Add(rdbTodosAlugueis);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 13);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(250, 124);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selecione um filtro:";
            // 
            // rdbTodosAlugueis
            // 
            rdbTodosAlugueis.AutoSize = true;
            rdbTodosAlugueis.Font = new Font("Segoe UI", 9F);
            rdbTodosAlugueis.Location = new Point(32, 31);
            rdbTodosAlugueis.Name = "rdbTodosAlugueis";
            rdbTodosAlugueis.Size = new Size(118, 19);
            rdbTodosAlugueis.TabIndex = 0;
            rdbTodosAlugueis.TabStop = true;
            rdbTodosAlugueis.Text = "Todos os aluguéis";
            rdbTodosAlugueis.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(187, 152);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 14;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(12, 152);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroAlugueisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 187);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaFiltroAlugueisForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TelaFiltroAlugueisForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton rdbAlugueisConcluidos;
        private RadioButton rdbAlugueisPendentes;
        private GroupBox groupBox1;
        private RadioButton rdbTodosAlugueis;
        private Button btnGravar;
        private Button btnCancelar;
    }
}