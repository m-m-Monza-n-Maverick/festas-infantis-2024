using eAgenda.WinApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloItem
{
    public partial class TabelaItemControl : UserControl
    {
        public TabelaItemControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        internal void AtualizarRegistros(List<Item> itens)
        {
            grid.Rows.Clear();

            foreach (Item item in itens)
                grid.Rows.Add(item.Id, item.Descricao.ToTitleCase(), item.Valor.ToString());
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
