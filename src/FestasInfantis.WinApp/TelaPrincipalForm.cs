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

        IRepositorioTema repositorioTema;
        IRepositorioItem repositorioItem;
        IRepositorioCliente repositorioCliente;
        RepositorioAluguelEmMemoria repositorioAluguel;

        public static TelaPrincipalForm Instancia { get; private set; }
        public TelaPrincipalForm()
        {
            InitializeComponent();

            lblTipoCadastro.Text = string.Empty;

            repositorioTema = new RepositorioTemaEmArquivo();
            repositorioItem = new RepositorioItemEmArquivo();
            repositorioCliente = new RepositorioClienteEmArquivo();
            repositorioAluguel = new();

            Instancia = this;
        }

        public void AtualizarRodape(string texto) => statusLabelPrincipal.Text = texto;
        public void AtualizaLblTipoCadastro(string cliente) => lblTipoCadastro.Text = "Visualizando os alugueis do cliente: " + cliente;


        #region Seleção de módulo
        private void temasMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorTema(repositorioTema, repositorioItem));
        private void itensToolStripMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorItem(repositorioItem));
        private void alugueisMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorAluguel(repositorioAluguel, repositorioCliente, repositorioTema));
        private void clientesMenuItem_Click(object sender, EventArgs e)
            => SelecionaModulo(ref controlador, () => controlador = new ControladorCliente(repositorioCliente));
        #endregion

        #region Botões
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
            ConfigurarToolBoxEspecial();
            ConfigurarListagem(controlador);

            if (controlador is IControladorVisualizavel controladorVisualizavel)
                controladorVisualizavel.VisualizarAlugueis();

            if (!btnVisualizarAlugueis.Checked)
                lblTipoCadastro.Text = "Cadastro de " + controlador.TipoCadastro;
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (controlador is IControladorFiltravel controladorFiltravel)
                controladorFiltravel.Filtrar();
        }
        #endregion

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
            btnAdicionar.Enabled = true;
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;

            btnConfigurarDescontos.Enabled = controladorSelecionado is IControladorDesconto;
            btnFiltrar.Enabled = controladorSelecionado is IControladorFiltravel;
            btnConcluirAluguel.Enabled = controladorSelecionado is IControladorConcluivel;
            btnVisualizarAlugueis.Enabled = controladorSelecionado is IControladorVisualizavel;
            btnVisualizarAlugueis.Checked = false;

            ConfigurarToolTips(controladorSelecionado);
        }
        private void ConfigurarToolBoxEspecial()
        {
            if (btnVisualizarAlugueis.Checked)
            {
                btnVisualizarAlugueis.Checked = false;
                btnAdicionar.Enabled = true;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                btnVisualizarAlugueis.Checked = true;
                btnAdicionar.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }
        private void ConfigurarToolTips(ControladorBase controladorSelecionado)
        {
            btnAdicionar.ToolTipText = controladorSelecionado.ToolTipAdicionar;
            btnEditar.ToolTipText = controladorSelecionado.ToolTipEditar;
            btnExcluir.ToolTipText = controladorSelecionado.ToolTipExcluir;

            if (controladorSelecionado is IControladorFiltravel controladorFiltravel)
                btnFiltrar.ToolTipText = controladorFiltravel.ToolTipFiltrar;

            if (controladorSelecionado is IControladorDesconto controladorDesconto)
                btnConfigurarDescontos.ToolTipText = controladorDesconto.ToolTipConfigurarDescontos;

            if (controladorSelecionado is IControladorConcluivel controladorConcluivel)
                btnConcluirAluguel.ToolTipText = controladorConcluivel.ToolTipConcluirAluguel;

            if (controladorSelecionado is IControladorVisualizavel controladorVisualizavel)
                btnVisualizarAlugueis.ToolTipText = controladorVisualizavel.ToolTipVisualizarAlugueis;
        }
        private void ConfigurarListagem(ControladorBase controladorSelecionado)
        {
            UserControl listagemContato;

            if (btnVisualizarAlugueis.Checked)
                listagemContato = controladorSelecionado.ObterListagemDeAlugueis();
            else
                listagemContato = controladorSelecionado.ObterListagem();

            listagemContato.Dock = DockStyle.Fill;
            pnlRegistros.Controls.Clear();
            pnlRegistros.Controls.Add(listagemContato);
        }
        #endregion
    }
}