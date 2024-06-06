namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TelaClienteForm : Form
    {
        private Cliente cliente;
        public Cliente Cliente
        {
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
                txtTelefone.Text = value.Telefone;
                txtCPF.Text = value.CPF;
            }
            get
            {
                return cliente;
            }
        }

        public TelaClienteForm(int id)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtCPF.PlaceholderText = "___.___.___-__";
            txtTelefone.PlaceholderText = "(__)_____-____";
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string telefone = txtTelefone.Text;
            string cPF = txtCPF.Text;

            cliente = new Cliente(nome, telefone, cPF);

            List<string> erros = cliente.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }
        }
        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número e nem backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

        }
    }
}
