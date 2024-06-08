using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloCliente;
using FestasInfantis.WinApp.ModuloItem;
using FestasInfantis.WinApp.ModuloTema;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    internal class ControladorAluguel (IRepositorioAluguel repositorioAluguel, IRepositorioCliente repositorioCliente,IRepositorioTema repositorioTema) : ControladorBase, IControladorDesconto, IControladorConcluivel, IControladorFiltravel
    {
        private IRepositorioAluguel repositorioAluguel = repositorioAluguel;
        private IRepositorioCliente repositorioCliente = repositorioCliente;
        private IRepositorioTema repositorioTema = repositorioTema;
        private TabelaAluguelControl tabelaAlugueis;

        #region ToolTips
        public override string TipoCadastro { get => "Aluguéis"; }
        public override string ToolTipAdicionar { get => "Adicionar novo aluguel"; }
        public override string ToolTipEditar { get => "Editar aluguel existente"; }
        public override string ToolTipExcluir { get => "Excluir aluguel existente"; }
        public string ToolTipConfigurarDescontos { get => "Configurar descontos"; }
        public string ToolTipConcluirAluguel { get => "Concluir um aluguel existente"; }
        public string ToolTipFiltrar { get => "Filtrar aluguéis"; }
        #endregion

        public override void Adicionar()
        {
            if (SemClientesOuTemas()) return; ;

            int id = repositorioAluguel.PegarId();

            TelaAluguelForm telaAluguel = new ( 
                id, 
                repositorioAluguel.PorcentDesconto, 
                repositorioAluguel.PorcentMaxDesconto );

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel novoAluguel = telaAluguel.Aluguel;

            novoAluguel.PorcentDesconto = novoAluguel.Cliente.NumDeAlugueis * repositorioAluguel.PorcentDesconto;

            RealizarAcao(
                () => repositorioAluguel.Cadastrar(novoAluguel),
                novoAluguel, "criado");

            AdicionarAluguelDoCliente(novoAluguel);

            id++;
        }
        public override void Editar()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (SemSeleção(aluguelSelecionado) || AluguelConcluido(aluguelSelecionado)) return;

            RemoverAluguelDoCliente(idSelecionado, aluguelSelecionado);

            TelaAluguelForm telaAluguel = new(idSelecionado, repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel aluguelEditado = telaAluguel.Aluguel;

            aluguelEditado.PorcentDesconto = aluguelEditado.Cliente.NumDeAlugueis * repositorioAluguel.PorcentDesconto;
            aluguelEditado.Id = idSelecionado;

            RealizarAcao(
                () => repositorioAluguel.Editar(aluguelSelecionado.Id, aluguelEditado),
                aluguelEditado, "editado");

            AdicionarAluguelDoCliente(aluguelEditado);
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (SemSeleção(aluguelSelecionado) || AluguelConcluido(aluguelSelecionado)) return;

            if (!DesejaRealmenteExcluir(aluguelSelecionado)) return;

            RemoverAluguelDoCliente(idSelecionado, aluguelSelecionado);

            RealizarAcao(
                () => repositorioAluguel.Excluir(aluguelSelecionado.Id),
                aluguelSelecionado, "excluído");
        }
        public void Filtrar()
        {
            TelaFiltroAlugueisForm telaFiltro = new();

            DialogResult resultado = telaFiltro.ShowDialog();

            if (resultado != DialogResult.OK) return;

            TipoFiltroAluguelEnum filtroSelecionado = telaFiltro.FiltroSelecionado;

            List<Aluguel> alugueisFiltrados;

            if (filtroSelecionado == TipoFiltroAluguelEnum.Pendente)
                alugueisFiltrados = repositorioAluguel.SelecionarCompromissosPendentes();

            else if (filtroSelecionado == TipoFiltroAluguelEnum.Concluido)
                alugueisFiltrados = repositorioAluguel.SelecionarCompromissosConcluidos();

            else alugueisFiltrados = repositorioAluguel.SelecionarTodos();

            tabelaAlugueis.AtualizarRegistros(alugueisFiltrados);

            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {alugueisFiltrados.Count} registros");
        }
        public void ConcluirAluguel()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (SemSeleção(aluguelSelecionado)) return;

            RemoverAluguelDoCliente(idSelecionado, aluguelSelecionado);

            TelaConcluirAluguelForm telaAluguel = new(aluguelSelecionado);

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            aluguelSelecionado = telaAluguel.Aluguel;

            if (resultado != DialogResult.OK) return;

            RealizarAcao(
                () => repositorioAluguel.Editar(aluguelSelecionado.Id, aluguelSelecionado),
                aluguelSelecionado, "concluído");

            AdicionarAluguelDoCliente(aluguelSelecionado);
        }
        public void ConfigurarDescontos()
        {
            TelaDescontoForm telaDesconto = new(repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            DialogResult resultado = telaDesconto.ShowDialog();

            if (resultado != DialogResult.OK) return;

            repositorioAluguel.PorcentDesconto = telaDesconto.porcentPorAluguel;
            repositorioAluguel.PorcentMaxDesconto = telaDesconto.porcentDescontoMax;

            AtualizarDesconto();
        }


        #region Auxiliares
        public override UserControl ObterListagem()
        {
            tabelaAlugueis ??= new();

            CarregarAlugueis();
            return tabelaAlugueis;
        }
        private void AtualizarDesconto()
        {
            foreach (Aluguel aluguel in repositorioAluguel.SelecionarTodos())
            {
                decimal desconto = aluguel.Cliente.NumDeAlugueis * repositorioAluguel.PorcentDesconto;

                if (desconto > repositorioAluguel.PorcentMaxDesconto) desconto = repositorioAluguel.PorcentMaxDesconto;

                aluguel.PorcentDesconto = desconto;

                repositorioAluguel.Editar(aluguel.Id, aluguel);
            }

            CarregarAlugueis();
        }
        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAlugueis.AtualizarRegistros(alugueis);
        }
        private void CarregarMensagem(Aluguel aluguel, string texto)
        {
            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O aluguel do tema \"{aluguel.Tema}\" foi {texto} com sucesso!");
        }
        private void RealizarAcao(Action acao, Aluguel aluguel, string texto)
        {
            acao();
            CarregarAlugueis();
            CarregarMensagem(aluguel, texto);
        }

        #region Validações
        private bool SemClientesOuTemas()
        {
            if (repositorioCliente.SelecionarTodos().Count == 0 || repositorioTema.SelecionarTodos().Count == 0)
            {
                MessageBox.Show(
                    "Não é possível cadastrar um aluguel\n\nNão existem Clientes e/ou Temas cadastrados",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }
            return false;
        }
        private bool AluguelConcluido(Aluguel aluguelSelecionado)
        {
            if (aluguelSelecionado.Concluido)
            {
                MessageBox.Show(
                    "Não é possível alterar um aluguel concluído",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        #endregion

        #region Clientes
        private void CarregarClientes(TelaAluguelForm telaAluguel)
        {
            List<Cliente> clientesCadastrados = repositorioCliente.SelecionarTodos();
            telaAluguel.CarregarClientes(clientesCadastrados);
        }
        private void AdicionarAluguelDoCliente(Aluguel aluguel)
        {
            aluguel.Cliente.Alugueis.Add(aluguel);
            repositorioCliente.Editar(aluguel.Cliente.Id, aluguel.Cliente);
        }
        private void RemoverAluguelDoCliente(int idSelecionado, Aluguel aluguelSelecionado)
        {
            List<Aluguel> lista = aluguelSelecionado.Cliente.Alugueis;

            foreach (Aluguel aluguel in lista)
                if (aluguel.Id == idSelecionado)
                {
                    aluguelSelecionado.Cliente.Alugueis.Remove(aluguel);
                    repositorioCliente.Editar(aluguelSelecionado.Cliente.Id, aluguelSelecionado.Cliente);
                    return;
                }
        }
        #endregion

        #region Temas
        private void CarregarTemas(TelaAluguelForm telaAluguel)
        {
            List<Tema> temasCadastrados = repositorioTema.SelecionarTodos();
            telaAluguel.CarregarTemas(temasCadastrados);
        }
        #endregion

        #endregion
    }
}
