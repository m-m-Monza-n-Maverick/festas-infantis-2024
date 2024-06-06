using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloAluguel;
namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TabelaAlugueisDoCliente : UserControl
    {
        Cliente clienteSelecionado;
        public TabelaAlugueisDoCliente(Cliente clienteSelecionado)
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();

            this.clienteSelecionado = clienteSelecionado;
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            grid.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                if (aluguel.Cliente == clienteSelecionado)
                {
                    string concluido, valorPendente;
                    if (aluguel.Concluido)
                    {
                        concluido = "Concluído";
                        valorPendente = "0";
                    }
                    else
                    {
                        concluido = "Aberto";
                        valorPendente = aluguel.ValorPendente.ToString();
                    }
                    grid.Rows.Add(aluguel.Id, concluido, aluguel.Cliente, aluguel.Tema, aluguel.PorcentEntrada * 100, aluguel.Festa, valorPendente);
                }
            }
        }

        public int ObterRegistroSelecionado() => grid.SelecionarId();

        private DataGridViewColumn[] ObterColunas()
        {
            return [ new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente" },
                     new DataGridViewTextBoxColumn { DataPropertyName = "Tema", HeaderText = "Tema"},
                     new DataGridViewTextBoxColumn { DataPropertyName = "% Entrada", HeaderText = "% Entrada"},
                     new DataGridViewTextBoxColumn { DataPropertyName = "Festa", HeaderText = "Festa"},
                     new DataGridViewTextBoxColumn { DataPropertyName = "ValorPendente", HeaderText = "Valor pendente"}, ];
        }
    }
}
