using eAgenda.WinApp.Compartilhado;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {
        public TabelaAluguelControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        internal void AtualizarRegistros(List<Aluguel> alugueis)
        {
            grid.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
                grid.Rows.Add(aluguel.Id);
        }

        public int ObterRegistroSelecionado() => grid.SelecionarId();
        private static DataGridViewColumn[] ObterColunas()
        {
            return [ new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"}, ];
        }

    }
}
