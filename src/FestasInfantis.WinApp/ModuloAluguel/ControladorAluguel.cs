using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloCliente;
using FestasInfantis.WinApp.ModuloTema;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    internal class ControladorAluguel (RepositorioAluguelEmMemoria repositorioAluguel, RepositorioClienteemMemoria repositorioCliente,RepositorioTemaEmMemoria repositorioTema) : ControladorBase, IControladorDesconto, IControladorConcluivel
    {
        private RepositorioAluguelEmMemoria repositorioAluguel = repositorioAluguel;
        private RepositorioClienteemMemoria repositorioCliente = repositorioCliente;
        private RepositorioTemaEmMemoria repositorioTema = repositorioTema;
        private TabelaAluguelControl tabelaAlugueis;
        public int id = 1;

        #region ToolTips
        public override string TipoCadastro { get => "Aluguéis"; }
        public override string ToolTipAdicionar { get => "Adicionar novo aluguel"; }
        public override string ToolTipEditar { get => "Editar aluguel existente"; }
        public override string ToolTipExcluir { get => "Excluir aluguel existente"; }
        public string ToolTipConfigurarDescontos { get => "Configurar descontos"; }
        public string ToolTipConcluirAluguel { get => "Concluir um aluguel existente"; }
        #endregion

        public override void Adicionar()
        {
            TelaAluguelForm telaAluguel = new(id, repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel novoAluguel = telaAluguel.Aluguel;

            novoAluguel.PorcentDesconto = novoAluguel.Cliente.NumDeAlugueis * repositorioAluguel.PorcentDesconto;

            RealizaAcao(
                () => repositorioAluguel.Cadastrar(novoAluguel),
                novoAluguel, "criado");

            novoAluguel.Cliente.Alugueis.Add(novoAluguel);

            id++;
        }
        public override void Editar()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            TelaAluguelForm telaAluguel = new(idSelecionado, repositorioAluguel.PorcentDesconto, repositorioAluguel.PorcentMaxDesconto);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            if (SemSeleção(aluguelSelecionado)) return;

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel aluguelEditado = telaAluguel.Aluguel;

            aluguelEditado.PorcentDesconto = aluguelEditado.Cliente.NumDeAlugueis * repositorioAluguel.PorcentDesconto;

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

            AtualizaAlugueis();
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

            RealizaAcao(
                () => repositorioAluguel.Editar(aluguelSelecionado.Id, aluguelSelecionado),
                aluguelSelecionado, "concluído");
        }


        #region Auxiliares
        public override UserControl ObterListagem()
        {
            tabelaAlugueis ??= new();

            CarregarAlugueis();
            return tabelaAlugueis;
        }
        private void AtualizaAlugueis()
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
        private void CarregarTemas(TelaAluguelForm telaAluguel)
        {
            List<Tema> temasCadastrados = repositorioTema.SelecionarTodos();
            if (temasCadastrados.Count == 0) temasCadastrados = [new("", [])];
            telaAluguel.CarregarTemas(temasCadastrados);
        }
        private void CarregarClientes(TelaAluguelForm telaAluguel)
        {
            List<Cliente> clientesCadastrados = repositorioCliente.SelecionarTodos();
            if (clientesCadastrados.Count == 0) clientesCadastrados = [new("Não há clientes...", "", "")];
            telaAluguel.CarregarClientes(clientesCadastrados);
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
        #endregion
    }
}
