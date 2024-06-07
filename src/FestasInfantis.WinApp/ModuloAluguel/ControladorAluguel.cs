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
            int id = repositorioAluguel.PegarId();

            TelaAluguelForm telaAluguel = new(id, repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel novoAluguel = telaAluguel.Aluguel;

            novoAluguel.PorcentDesconto = novoAluguel.Cliente.NumDeAlugueis * repositorioAluguel.PorcentDesconto;

            AdicionarAluguelDoCliente(novoAluguel);

            RealizaAcao(
                () => repositorioAluguel.Cadastrar(novoAluguel),
                novoAluguel, "criado");

            id++;
        }
        public override void Editar()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (AluguelConcluido(aluguelSelecionado)) return;

            TelaAluguelForm telaAluguel = new(idSelecionado, repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            if (SemSeleção(aluguelSelecionado)) return;

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel aluguelEditado = telaAluguel.Aluguel;

            aluguelEditado.PorcentDesconto = aluguelEditado.Cliente.NumDeAlugueis * repositorioAluguel.PorcentDesconto;

            EditarAluguelDoCliente(aluguelSelecionado, aluguelEditado);

            RealizaAcao(
                () => repositorioAluguel.Editar(aluguelSelecionado.Id, aluguelEditado),
                aluguelEditado, "editado");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (SemSeleção(aluguelSelecionado)) return;

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{aluguelSelecionado}\"?",
                $"Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes) return;

            RemoverAluguelDoCliente(aluguelSelecionado);

            RealizaAcao(
                () => repositorioAluguel.Excluir(aluguelSelecionado.Id),
                aluguelSelecionado, "excluído");
        }
        public void ConfigurarDescontos()
        {
            TelaDescontoForm telaDesconto = new(repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            DialogResult resultado = telaDesconto.ShowDialog();

            if (resultado != DialogResult.OK) return;

            repositorioAluguel.PorcentDesconto = telaDesconto.porcentPorAluguel;
            repositorioAluguel.PorcentMaxDesconto = telaDesconto.porcentDescontoMax;

            AtualizaDesconto();
        }
        public void ConcluirAluguel()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            if (SemSeleção(aluguelSelecionado)) return;

            TelaConcluirAluguelForm telaAluguel = new(aluguelSelecionado);

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            aluguelSelecionado = telaAluguel.Aluguel;

            if (resultado != DialogResult.OK) return;

            ConcluirAluguelCliente(aluguelSelecionado);

            RealizaAcao(
                () => repositorioAluguel.Editar(aluguelSelecionado.Id, aluguelSelecionado),
                aluguelSelecionado, "concluído");
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


        #region Auxiliares
        public override UserControl ObterListagem()
        {
            tabelaAlugueis ??= new();

            CarregarAlugueis();
            return tabelaAlugueis;
        }
        private void AtualizaDesconto()
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
        private bool AluguelConcluido(Aluguel aluguelSelecionado)
        {
            if (aluguelSelecionado.Concluido)
            {
                MessageBox.Show(
                    "Não é possível editar um aluguel concluído",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
        private void CarregaMensagem(Aluguel aluguel, string texto)
        {
            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O aluguel do tema \"{aluguel.Tema}\" foi {texto} com sucesso!");
        }
        private void RealizaAcao(Action acao, Aluguel aluguel, string texto)
        {
            acao();
            CarregarAlugueis();
            CarregaMensagem(aluguel, texto);
        }

        #region Clientes
        private void CarregarClientes(TelaAluguelForm telaAluguel)
        {
            List<Cliente> clientesCadastrados = repositorioCliente.SelecionarTodos();
            if (clientesCadastrados.Count == 0) clientesCadastrados = [new("Não há clientes...", "", "")];
            telaAluguel.CarregarClientes(clientesCadastrados);
        }
        private void AdicionarAluguelDoCliente(Aluguel novoAluguel)
        {
            novoAluguel.Cliente.Alugueis.Add(novoAluguel);
            repositorioCliente.Editar(novoAluguel.Cliente.Id, novoAluguel.Cliente);
        }
        private void EditarAluguelDoCliente(Aluguel aluguelSelecionado, Aluguel aluguelEditado)
        {
            if (aluguelEditado.Cliente != aluguelSelecionado.Cliente)
            {
                aluguelEditado.Id = aluguelSelecionado.Id;

                aluguelEditado.Cliente.Alugueis.Add(aluguelEditado);
                aluguelSelecionado.Cliente.Alugueis.Remove(aluguelSelecionado);

                repositorioCliente.Editar(aluguelEditado.Cliente.Id, aluguelEditado.Cliente);
                repositorioCliente.Editar(aluguelSelecionado.Cliente.Id, aluguelSelecionado.Cliente);
            }
        }
        private void RemoverAluguelDoCliente(Aluguel aluguel)
        {
            aluguel.Cliente.Alugueis.Remove(aluguel);
            repositorioCliente.Editar(aluguel.Cliente.Id, aluguel.Cliente);
        }
        private void ConcluirAluguelCliente(Aluguel aluguelSelecionado)
        {
            List<Aluguel> alugueisCliente = aluguelSelecionado.Cliente.Alugueis;

            foreach (Aluguel aluguel in alugueisCliente)
                if (aluguel.Id == aluguelSelecionado.Id)
                {
                    aluguelSelecionado.Cliente.Alugueis.Remove(aluguel);
                    aluguelSelecionado.Cliente.Alugueis.Add(aluguelSelecionado);
                    repositorioCliente.Editar(aluguelSelecionado.Cliente.Id, aluguelSelecionado.Cliente);
                }
        }
        #endregion

        #region Temas
        private void CarregarTemas(TelaAluguelForm telaAluguel)
        {
            List<Tema> temasCadastrados = repositorioTema.SelecionarTodos();
            if (temasCadastrados.Count == 0) temasCadastrados = [new("", [])];
            telaAluguel.CarregarTemas(temasCadastrados);
        }
        #endregion

        #endregion
    }
}
