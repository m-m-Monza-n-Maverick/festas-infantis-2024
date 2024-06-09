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

            AdicionarAluguelDoCliente(novoAluguel);

            RealizarAcao(
                () => repositorioAluguel.Cadastrar(novoAluguel),
                novoAluguel, "criado");

            id++;
        }
        public override void Editar()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (SemSeleção(aluguelSelecionado) || AluguelConcluido(aluguelSelecionado)) return;

            TelaAluguelForm telaAluguel = new(idSelecionado, repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel aluguelEditado = telaAluguel.Aluguel;

            aluguelEditado.Id = idSelecionado;

            RemoverAluguelDoCliente(aluguelSelecionado);
            AdicionarAluguelDoCliente(aluguelEditado);

            RealizarAcao(
                () => repositorioAluguel.Editar(aluguelSelecionado.Id, aluguelEditado),
                aluguelEditado, "editado");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (SemSeleção(aluguelSelecionado) || AluguelConcluido(aluguelSelecionado)) return;

            if (!DesejaRealmenteExcluir(aluguelSelecionado)) return;

            RemoverAluguelDoCliente(aluguelSelecionado);

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

            RemoverAluguelDoCliente(aluguelSelecionado);
            AdicionarAluguelDoCliente(aluguelSelecionado);

            if (SemSeleção(aluguelSelecionado)) return;

            TelaConcluirAluguelForm telaAluguel = new(aluguelSelecionado);

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            aluguelSelecionado = telaAluguel.Aluguel;

            if (resultado != DialogResult.OK) return;

            RealizarAcao(
                () => repositorioAluguel.Editar(aluguelSelecionado.Id, aluguelSelecionado),
                aluguelSelecionado, "concluído");
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
                decimal desconto = aluguel.Cliente.AlugueisConcluidos * repositorioAluguel.PorcentDesconto;

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
        private void AdicionarAluguelDoCliente(Aluguel aluguel) => aluguel.Cliente.Alugueis.Add(aluguel);
        private void RemoverAluguelDoCliente(Aluguel aluguelSelecionado)
        {
            foreach (Aluguel aluguel in aluguelSelecionado.Cliente.Alugueis)
            {
                if (aluguel.Id == aluguelSelecionado.Id)
                {
                    aluguel.Cliente.Alugueis.Remove(aluguel);
                    return; 
                }
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
