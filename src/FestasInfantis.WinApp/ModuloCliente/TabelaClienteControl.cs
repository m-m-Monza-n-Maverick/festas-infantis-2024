using eAgenda.WinApp.Compartilhado;

namespace FestasInfantis.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();

            grid.Columns.AddRange(ObterColunas());
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();

            foreach (Cliente c in clientes)
                grid.Rows.Add(c.Id, c.Nome.ToTitleCase(), MostraTelefone(c), MostraCPF(c));
        }

        public int ObterRegistroSelecionado() => grid.SelecionarId();

        private DataGridViewColumn[] ObterColunas()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" },
                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone" },
                new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF" },
            };
        }

        private static string MostraTelefone(Cliente c)
        {
            char[] telefone = c.Telefone.ToCharArray();
            string ddd = "", parte1 = "", parte2 = "";

            for (int i = 0; i < 11; i++)
            {
                if (i < 2) ddd += telefone[i];
                else if (i < 7) parte1 += telefone[i];
                else parte2 += telefone[i];
            }

            return $"({ddd}){parte1}-{parte2}";
        }
        private static string MostraCPF(Cliente c)
        {
            char[] cpf = c.CPF.ToCharArray();
            string parte1 = "", parte2 = "", parte3 = "", parte4 = "";

            for (int i = 0; i < 11; i++)
            {
                if (i < 3) parte1 += cpf[i];
                else if (i < 6) parte2 += cpf[i];
                else if (i < 9) parte3 += cpf[i];
                else parte4 += cpf[i];
            }

            return $"{parte1}.{parte2}.{parte3}-{parte4}";
        }
    }
}
