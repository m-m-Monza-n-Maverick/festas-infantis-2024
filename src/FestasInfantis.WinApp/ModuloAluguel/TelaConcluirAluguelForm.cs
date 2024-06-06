namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaConcluirAluguelForm : Form
    {
        private Aluguel aluguel;
        public Aluguel Aluguel
        {
            get => aluguel;
            set
            {
                txtId.Text = value.Id.ToString();
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

                txtPercentDesconto.Text = value.PorcentDesconto.ToString();
                txtValorTema.Text = value.Tema.Valor.ToString();
                txtValorEntrada.Text = value.ValorEntrada.ToString();
                txtTemaComDesconto.Text = value.ValorTemaComDesconto.ToString();
                txtValorPendente.Text = value.ValorPendente.ToString();
            }
        }

        public TelaConcluirAluguelForm(Aluguel aluguelSelecionado)
        {
            InitializeComponent();
            aluguel = aluguelSelecionado;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            aluguel.Concluido = true;
            aluguel.Cliente.NumDeAlugueis++;
        }
    }
}
