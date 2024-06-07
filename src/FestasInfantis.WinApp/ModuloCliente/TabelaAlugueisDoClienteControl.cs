using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloAluguel;
namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TabelaAlugueisDoClienteControl : UserControl
    {
        public TabelaAlugueisDoClienteControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            grid.Rows.Clear();

            if (alugueis == null) return;

            foreach (Aluguel aluguel in alugueis)
            {
                string concluido = "Pendente", dataPagamento = "";

                if (aluguel.Concluido)
                {
                    concluido = "Concluído";
                    dataPagamento = aluguel.DataPagam.ToShortDateString();
                }

                grid.Rows.Add(aluguel.Id, concluido, aluguel.Tema, aluguel.ValorPendente, dataPagamento);
            }
        }
        private DataGridViewColumn[] ObterColunas()
        { 
            return 
            [ 
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Tema", HeaderText = "Tema"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPendente", HeaderText = "Valor pendente"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DataPagamento", HeaderText = "Data do pagamento"},
            ];
        }
    }
}
