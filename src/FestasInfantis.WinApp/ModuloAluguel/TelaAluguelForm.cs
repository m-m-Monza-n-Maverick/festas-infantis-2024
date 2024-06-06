using eAgenda.ConsoleApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        decimal porcentDesconto, descontoMax;

        private Aluguel aluguel;
        public Aluguel Aluguel
        {
            get => aluguel;
            set
            {
                dtpDataFesta.Value = value.Festa.DataFesta;
                mskHoraInicio.Text = value.Festa.HoraInicio.ToString();
                mskHoraFim.Text = value.Festa.HoraFim.ToString();
                txtRua.Text = value.Festa.Rua;
                txtNumero.Text = value.Festa.Numero;
                txtBairro.Text = value.Festa.Bairro;
                txtCidade.Text = value.Festa.Cidade;
                cmbEstado.Text = value.Festa.Estado;

                cmbClientes.Text = value.Cliente.ToString();
                cmbTema.Text = value.Tema.ToString();
                cmbPercentEntrada.Text = (value.PorcentEntrada * 100).ToString();
            }
        }

        public TelaAluguelForm(int id, decimal porcentDesconto, decimal descontoMax)
        {
            InitializeComponent();
            txtId.Text = id.ToString();

            ConfiguraComboBox();

            this.porcentDesconto = porcentDesconto;
            this.descontoMax = descontoMax;
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
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Festa festa = new("rua", "numero", "bairro", "cidade", "estado", DateTime.Now, TimeSpan.MinValue, TimeSpan.MinValue);
            RecebeInformacoesDoAluguel(festa);            
            ValidaCampos(aluguel);

            if (DialogResult == DialogResult.None) return;

            txtPercentDesconto.Text = aluguel.PorcentDesconto.ToString();
            txtValorTema.Text = aluguel.Tema.Valor.ToString();
            txtValorEntrada.Text = aluguel.ValorEntrada.ToString();
            txtTemaComDesconto.Text = aluguel.ValorTemaComDesconto.ToString();
            txtValorPendente.Text = aluguel.ValorPendente.ToString();

            DialogResult = DialogResult.None;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            DateTime dataFesta = dtpDataFesta.Value;
            TimeSpan horaInicio = ValidaHora(mskHoraInicio.Text);
            TimeSpan horaFim = ValidaHora(mskHoraFim.Text);
            string rua = txtRua.Text, numero = txtNumero.Text, bairro = txtBairro.Text, cidade = txtCidade.Text;
            string estado = ValidaEstado();

            Festa festa = new(rua, numero, bairro, cidade, estado, dataFesta, horaInicio, horaFim);
            RecebeInformacoesDoAluguel(festa);
            ValidaCampos(aluguel);
        }
        private void RecebeInformacoesDoAluguel(Festa festa)
        {
            Cliente cliente = (Cliente)cmbClientes.SelectedItem;
            Tema tema = (Tema)cmbTema.SelectedItem;
            decimal porcentEntrada = ValidaPorcentagem();
            decimal desconto = ContabilizaDesconto(cliente);

            aluguel = new(cliente, tema, porcentEntrada, desconto, festa);
        }


        #region Auxiliares
        private void ValidaCampos(EntidadeBase entidade)
        {
            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
            else DialogResult = DialogResult.OK;
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
        private decimal ContabilizaDesconto(Cliente cliente)
        {
            decimal desconto = 0;

            if (cliente != null) desconto = cliente.NumDeAlugueis * porcentDesconto;

            if (desconto <= descontoMax) return desconto;
            else return descontoMax;
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
        private void btnAdicionar_Click(object sender, EventArgs e) { }
        #endregion




    }
}
