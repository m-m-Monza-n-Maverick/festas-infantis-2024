using eAgenda.ConsoleApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private Aluguel aluguel;
        public Aluguel Aluguel
        {
            get => aluguel;
            set
            {

            }
        }
        public TelaAluguelForm(int id)
        {
            InitializeComponent();
            txtId.Text = id.ToString();

            ConfiguraComboBox();
        }

        public void CarregarClientes(List<Cliente> clientes)
        {
            cmbClientes.Items.Clear();
            foreach (Cliente cliente in clientes)
                cmbClientes.Items.Add(cliente);
        }
        public void CarregarTemas(List<Tema> temas)
        {
            cmbTema.Items.Clear();
            foreach (Tema tema in temas)
                cmbTema.Items.Add(tema);
        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            DateTime dataFesta = dtpDataFesta.Value;
            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFim = dtpHoraFim.Value.TimeOfDay;
            string rua = txtRua.Text, numero = txtNumero.Text, bairro = txtBairro.Text, cidade = txtCidade.Text, estado = cmbEstado.Text;

            Festa festa = new(rua, Convert.ToInt32(numero), bairro, cidade, estado, dataFesta, horaInicio, horaFim);

            Cliente cliente = (Cliente)cmbClientes.SelectedItem;
            Tema tema = (Tema)cmbTema.SelectedItem;
            string[] sinal = cmbPercentEntrada.Text.Split('%');
            decimal porcentEntrada = 0;

            if (sinal[0] != "") porcentEntrada = Convert.ToDecimal(sinal[0]) / 100;

            aluguel = new(cliente, tema, porcentEntrada, festa);

            ValidacaoDeCampos(aluguel);
        }
        private void ValidacaoDeCampos(EntidadeBase entidade)
        {
            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
        private void ConfiguraComboBox()
        {
            cmbEstado.Items.AddRange(["AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"]);
            cmbPercentEntrada.Items.AddRange(["40%", "50%"]);
        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
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
