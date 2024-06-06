using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloAluguel;
using FestasInfantis.WinApp.ModuloCliente;
using FestasInfantis.WinApp.ModuloItem;
using FestasInfantis.WinApp.ModuloTema;
using FestasInfantis.WinFormsApp.ModuloCliente;
namespace FestasInfantis.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        ControladorBase controlador;

        RepositorioTema repositorioTema;
        RepositorioItem repositorioItem;
        RepositorioCliente reposistoCliente;
        RepositorioAluguel repositorioAluguel;

        public static TelaPrincipalForm Instancia { get; private set; }
        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;

            repositorioTema = new();
            repositorioTema.Cadastrar(new("Tema", [new("Item", 50)]));
            repositorioItem = new();
            reposistoCliente = new();
            reposistoCliente.Cadastrar(new("Cliente", "123", "123"));
            repositorioAluguel = new();


            Instancia = this;
        }


        public void AtualizarRodape(string texto) => statusLabelPrincipal.Text = texto;


        private void temasMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorTema(repositorioTema, repositorioItem));
        private void itensToolStripMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorItem(repositorioItem));
        private void alugueisMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorAluguel(repositorioAluguel, reposistoCliente, repositorioTema));
        private void clientesMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorCliente(reposistoCliente));


        private void btnAdicionar_Click(object sender, EventArgs e)
            => controlador.Adicionar();
        private void btnEditar_Click(object sender, EventArgs e)
            => controlador.Editar();
        private void btnExcluir_Click(object sender, EventArgs e)
            => controlador.Excluir();
        private void btnConfigurarDescontos_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorDesconto controladorDesconto)
                controladorDesconto.ConfigurarDescontos();
        }
        private void btnConcluirAluguel_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorConcluivel controladorConcluivel)
                controladorConcluivel.ConcluirAluguel();
        }
        private void btnVisualizarAlugueis_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorVisualizavel controladorVisualizavel)
                controladorVisualizavel.VisualizarAlugueis();
        }

        #region Auxiliares
        private void SelecionaModulo(ref ControladorBase controlador, Action controladorSelecionado)
        {
            controladorSelecionado();
            lblTipoCadastro.Text = "Cadastro de " + controlador.TipoCadastro;
            ConfigurarToolBox(controlador);
            ConfigurarListagem(controlador);
        }
        private void ConfigurarToolBox(ControladorBase controladorSelecionado)
        {
            btnAdicionar.Enabled = controladorSelecionado is ControladorBase;
            btnEditar.Enabled = controladorSelecionado is ControladorBase;
            btnExcluir.Enabled = controladorSelecionado is ControladorBase;
            btnConfigurarDescontos.Enabled = controladorSelecionado is IControladorDesconto;
            btnFiltrar.Enabled = controladorSelecionado is IControladorFiltravel;
            btnConcluirAluguel.Enabled = controladorSelecionado is IControladorConcluivel;
            btnVisualizarAlugueis.Enabled = controladorSelecionado is IControladorVisualizavel;

            ConfigurarToolTips(controladorSelecionado);
        }
        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            if (controladorSelecionado is IControladorFiltravel controladorFiltravel)
                btnFiltrar.ToolTipText = controladorFiltravel.ToolTipFiltrar;
        }
        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagemContato = controladorSelecionado.ObterListagem();
            listagemContato.Dock = DockStyle.Fill;

            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagemContato);
        }
        #endregion
    }
}
