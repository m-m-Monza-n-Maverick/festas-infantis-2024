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
            {
                string concluido, valorPendente;

                if (aluguel.Concluido) concluido = "Concluído";
                else concluido = "Aberto";

                grid.Rows.Add(aluguel.Id, concluido, aluguel.Cliente, aluguel.Tema, aluguel.PorcentEntrada * 100, aluguel.Festa, aluguel.ValorPendente);
            }
        }

        public int ObterRegistroSelecionado() => grid.SelecionarId();
        private static DataGridViewColumn[] ObterColunas()
        {
            return [ new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Tema", HeaderText = "Tema"},
                     new DataGridViewTextBoxColumn { DataPropertyName = "% Entrada", HeaderText = "% Entrada"},
                     new DataGridViewTextBoxColumn { DataPropertyName = "Festa", HeaderText = "Festa"},
                     new DataGridViewTextBoxColumn { DataPropertyName = "ValorPendente", HeaderText = "Valor pendente"},
            ];
        }
    }
}
