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
            RecebeInformacoesDoAluguel();
            ValidacaoDeCampos(aluguel);
        }

        #region Auxiliares
        private void ValidacaoDeCampos(EntidadeBase entidade)
        {
            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
        private TimeSpan ValidaHora(string horario)
        {
            string[] hora = horario.Split(':');

            if (horario != "  :")
                if (Convert.ToInt16(hora[0]) <= 23 && Convert.ToInt16(hora[1]) <= 59)
                    return TimeSpan.Parse(mskHoraInicio.Text);
            return TimeSpan.Zero;
        }
        private decimal ValidaPorcentagem()
        {
            string[] sinal = cmbPercentEntrada.Text.Split('%');
            if (sinal[0] != "") return Convert.ToDecimal(sinal[0]) / 100;
            return 0;
        }
        private string ValidaEstado()
        {
            if (cmbEstado.Items.Contains(cmbEstado.Text.ToUpper())) return cmbEstado.Text;
            return "";
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
        private void dtpDataFesta_ValueChanged(object sender, EventArgs e) => dtpDataFesta.CustomFormat = "dd/MM/yyyy";
        #endregion

        private void btnAdicionar_Click(object sender, EventArgs e) { }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            RecebeInformacoesDoAluguel();

            List<string> erros = aluguel.Validar();
            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                return;
            }

            txtPercentDesconto.Text = aluguel.PorcentDesconto.ToString();
            txtValorTema.Text = aluguel.Tema.Valor.ToString();
            txtValorEntrada.Text = aluguel.ValorEntrada.ToString();
            txtTemaComDesconto.Text = aluguel.ValorTemaComDesconto.ToString();
            txtValorPendente.Text = aluguel.ValorPendente.ToString();
        }

        private void RecebeInformacoesDoAluguel()
        {
            DateTime dataFesta = dtpDataFesta.Value;
            TimeSpan horaInicio = ValidaHora(mskHoraInicio.Text);
            TimeSpan horaFim = ValidaHora(mskHoraFim.Text);
            string rua = txtRua.Text, numero = txtNumero.Text, bairro = txtBairro.Text, cidade = txtCidade.Text;
            string estado = ValidaEstado();

            Festa festa = new(rua, numero, bairro, cidade, estado, dataFesta, horaInicio, horaFim);

            Cliente cliente = (Cliente)cmbClientes.SelectedItem;
            Tema tema = (Tema)cmbTema.SelectedItem;
            decimal porcentEntrada = ValidaPorcentagem();

            aluguel = new(cliente, tema, porcentEntrada, festa);
        }
    }
}
