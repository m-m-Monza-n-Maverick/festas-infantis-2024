using eAgenda.ConsoleApp.Compartilhado;
using FestasInfantis.WinApp.ModuloItem;
namespace FestasInfantis.WinApp.ModuloTema
{
    public partial class TelaTemaForm : Form
    {
        private Tema tema;
        public Tema Tema
        {
            get => tema;
            set
            {
                txtId.Text = value.Id.ToString();
                txtNome.Text = value.Nome;
            }
        }

        public TelaTemaForm(IRepositorioItem repositorioItem, int id, Tema temaAtual)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            ConfigurarListaDeItens(repositorioItem, temaAtual);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            List<Item> itens = [];

            foreach (Item item in listSelecaoItens.Items)
                item.Tema = null;

            foreach (Item item in listSelecaoItens.CheckedItems) 
                itens.Add(item);

            tema = new Tema(nome, itens);

            ValidacaoDeCampos(tema);
        }
        private void ValidacaoDeCampos(EntidadeBase entidade)
        {
            List<string> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
        }
        private void ConfigurarListaDeItens(IRepositorioItem repositorioItem, Tema temaAtual)
        {
            int i = 0;

            listSelecaoItens.Items.Clear();

            foreach (Item item in repositorioItem.SelecionarTodos())
            {
                if (item.Tema == null) listSelecaoItens.Items.Add(item);
                else if (temaAtual != null) if (item.Tema.Nome == temaAtual.Nome)
                {
                    listSelecaoItens.Items.Add(item);
                    listSelecaoItens.SetItemChecked(i, true);
                    i++;
                }
            }
        }
    }
}
