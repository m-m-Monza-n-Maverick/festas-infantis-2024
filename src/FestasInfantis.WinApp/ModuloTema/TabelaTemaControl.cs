using eAgenda.WinApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloTema
{
    public partial class TabelaTemaControl : UserControl
    {
        public TabelaTemaControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        internal void AtualizarRegistros(List<Tema> temas)
        {
            grid.Rows.Clear();

            foreach (Tema tema in temas)
                grid.Rows.Add(tema.Id, tema.Nome.ToTitleCase(), tema.Valor.ToString());
        }

        public int ObterRegistroSelecionado() => grid.SelecionarId();
        private static DataGridViewColumn[] ObterColunas()
        {
            return [ new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor"}, ];
        }
    }
}
