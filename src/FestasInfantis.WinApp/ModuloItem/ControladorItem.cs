using eAgenda.WinApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloItem
{
    internal class ControladorItem(RepositorioItem repositorioItem) : ControladorBase
    {
        private RepositorioItem repositorioItem = repositorioItem;
        private TabelaItemControl tabelaItens;
        public int id = 1;

        #region ToolTips
        public override string TipoCadastro { get => "Itens"; }
        public override string ToolTipAdicionar { get => "Adicionar novo item"; }
        public override string ToolTipEditar { get => "Editar item existente"; }
        public override string ToolTipExcluir { get => "Excluir item existente"; }
        #endregion

        public override void Adicionar()
        {
            TelaItemForm telaItem = new(id);
            DialogResult resultado = telaItem.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Item novoItem = telaItem.Item;

            RealizaAcao(
                () => repositorioItem.Cadastrar(novoItem),
                novoItem, "criado");

            id++;
        }
        public override void Editar()
        {
            int idSelecionado = tabelaItens.ObterRegistroSelecionado();

            TelaItemForm telaItem = new(idSelecionado);

            Item itemSelecionado = repositorioItem.SelecionarPorId(idSelecionado);

            if (SemSeleção(itemSelecionado)) return;

            telaItem.Item = itemSelecionado;

            DialogResult resultado = telaItem.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Item temaEditado = telaItem.Item;

            RealizaAcao(
                () => repositorioItem.Editar(itemSelecionado.Id, temaEditado),
                temaEditado, "editado");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaItens.ObterRegistroSelecionado();

            Item itemSelecionado = repositorioItem.SelecionarPorId(idSelecionado);

            if (SemSeleção(itemSelecionado)) return;

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{itemSelecionado.Descricao}\"?",
                $"Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes) return;

            itemSelecionado.Valor = 0;

            RealizaAcao(
                () => repositorioItem.Excluir(itemSelecionado.Id),
                itemSelecionado, "excluído");
        }

        #region Auxiliares
        public override UserControl ObterListagem()
        {
            tabelaItens ??= new();

            CarregarItems();
            return tabelaItens;
        }
        private void CarregarItems()
        {
            List<Item> itens = repositorioItem.SelecionarTodos();

            tabelaItens.AtualizarRegistros(itens);
        }
        private void CarregaMensagem(Item Item, string texto)
        {
            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{Item.Descricao}\" foi {texto} com sucesso!");
        }
        private void RealizaAcao(Action acao, Item tema, string texto)
        {
            acao();
            CarregarItems();
            CarregaMensagem(tema, texto);
        }
        #endregion
    }
}
