using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloTema;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    internal class ControladorAluguel (RepositorioAluguel repositorioAluguel, RepositorioTema repositorioTema) : ControladorBase
    {
        private RepositorioAluguel repositorioAluguel = repositorioAluguel;
        //private RepositorioCliente repositorioCliente = repositorioCliente;
        private RepositorioTema repositorioTema = repositorioTema;
        private TabelaAluguelControl tabelaAlugueis;
        public int id = 1;

        #region ToolTips
        public override string TipoCadastro { get => "Aluguéis"; }
        public override string ToolTipAdicionar { get => "Adicionar novo aluguel"; }
        public override string ToolTipEditar { get => "Editar aluguel existente"; }
        public override string ToolTipExcluir { get => "Excluir aluguel existente"; }
        #endregion

        public override void Adicionar()
        {
            TelaAluguelForm telaAluguel = new(id);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel novoAluguel = telaAluguel.Aluguel;

            RealizaAcao(
                () => repositorioAluguel.Cadastrar(novoAluguel),
                novoAluguel, "criado");

            id++;
        }
        public override void Editar()
        {
            int idSelecionado = tabelaAlugueis.ObterRegistroSelecionado();
            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(idSelecionado);

            TelaAluguelForm telaAluguel = new(idSelecionado);

            CarregarClientes(telaAluguel);
            CarregarTemas(telaAluguel);

            if (SemSeleção(aluguelSelecionado)) return;

            telaAluguel.Aluguel = aluguelSelecionado;

            DialogResult resultado = telaAluguel.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Aluguel aluguelEditado = telaAluguel.Aluguel;

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

        #region Auxiliares
        public override UserControl ObterListagem()
        {
            tabelaAlugueis ??= new();

            CarregarAlugueis();
            return tabelaAlugueis;
        }
        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAlugueis.AtualizarRegistros(alugueis);
        }
        private void CarregarTemas(TelaAluguelForm telaAluguel)
        {
            List<Tema> temasCadastrados = repositorioTema.SelecionarTodos();
            if (temasCadastrados.Count == 0) temasCadastrados = [new("não cadastrado..........", [])];
            telaAluguel.CarregarTemas(temasCadastrados);
        }
        private void CarregarClientes(TelaAluguelForm telaAluguel)
        {
            /*            List<Cliente> clientesCadastrados = repositorioCliente.SelecionarTodos();
                        if (clientesCadastrados.Count == 0) clientesCadastrados = [new()];
                        telaAluguel.CarregarClientes(clientesCadastrados);*/
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
