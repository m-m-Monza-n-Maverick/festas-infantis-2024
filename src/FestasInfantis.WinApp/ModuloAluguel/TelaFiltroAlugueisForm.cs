namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TelaFiltroAlugueisForm : Form
    {
        public TipoFiltroAluguelEnum FiltroSelecionado { get; private set; }

        public TelaFiltroAlugueisForm()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (rdbTodosAlugueis.Checked)
                FiltroSelecionado = TipoFiltroAluguelEnum.Todos;

            else if (rdbAlugueisPendentes.Checked)
                FiltroSelecionado = TipoFiltroAluguelEnum.Pendente;

            else if (rdbAlugueisConcluidos.Checked)
                FiltroSelecionado = TipoFiltroAluguelEnum.Concluido;
        }
    }

    public enum TipoFiltroAluguelEnum
    {
        Todos,
        Pendente,
        Concluido
    }
}
