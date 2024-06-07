using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloItem;
namespace FestasInfantis.WinApp.ModuloTema
{
    internal class ControladorTema(IRepositorioTema repositorioTema, IRepositorioItem repositorioItem) : ControladorBase
    {
        private IRepositorioTema repositorioTema = repositorioTema;
        private IRepositorioItem repositorioItem = repositorioItem;
        private TabelaTemaControl tabelaTemas;

        #region ToolTips
        public override string TipoCadastro { get => "Temas"; }
        public override string ToolTipAdicionar { get => "Adicionar novo tema"; }
        public override string ToolTipEditar { get => "Editar tema existente"; }
        public override string ToolTipExcluir { get => "Excluir tema existente"; }
        #endregion

        public override void Adicionar()
        {
            int id = repositorioTema.PegarId();
            TelaTemaForm telaTema = new(repositorioItem, id, null);
            DialogResult resultado = telaTema.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Tema novoTema = telaTema.Tema;

            RealizaAcao(
                () => repositorioTema.Cadastrar(novoTema),
                novoTema, "criado");
        }
        public override void Editar()
        {
            int idSelecionado = tabelaTemas.ObterRegistroSelecionado();

            Tema temaSelecionado = repositorioTema.SelecionarPorId(idSelecionado);

            TelaTemaForm telaTema = new(repositorioItem, idSelecionado, temaSelecionado);

            if (SemSeleção(temaSelecionado)) return;

            telaTema.Tema = temaSelecionado;

            DialogResult resultado = telaTema.ShowDialog();

            if (resultado != DialogResult.OK) return;

            Tema temaEditado = telaTema.Tema;

            RealizaAcao(
                () => repositorioTema.Editar(temaSelecionado.Id, temaEditado),
                temaEditado, "editado");
        }
        public override void Excluir()
        {
            int idSelecionado = tabelaTemas.ObterRegistroSelecionado();

            Tema temaSelecionado = repositorioTema.SelecionarPorId(idSelecionado);

            if (SemSeleção(temaSelecionado)) return;

            DialogResult resposta = MessageBox.Show(
                $"Você deseja realmente excluir o registro \"{temaSelecionado.Nome}\"?",
                $"Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resposta != DialogResult.Yes) return;

            RealizaAcao(
                () => repositorioTema.Excluir(temaSelecionado.Id),
                temaSelecionado, "excluído");

            LiberaItem(repositorioItem, temaSelecionado);
        }

        #region Auxiliares
        public override UserControl ObterListagem()
        {
            tabelaTemas ??= new();

            CarregarTemas();
            return tabelaTemas;
        }
        private void CarregarTemas()
        {
            List<Tema> temas = repositorioTema.SelecionarTodos();

            tabelaTemas.AtualizarRegistros(temas);
        }
        private static void LiberaItem(IRepositorioItem repositorioItem, Tema temaSelecionado)
        {
            foreach (Item item in repositorioItem.SelecionarTodos())
                foreach (Item itemTema in temaSelecionado.Itens)
                    if (item == itemTema) item.Tema = null;
        }
        private void CarregaMensagem(Tema Tema, string texto)
        {
            TelaPrincipalForm
                .Instancia
                .AtualizarRodape($"O registro \"{Tema.Nome}\" foi {texto} com sucesso!");
        }
        private void RealizaAcao(Action acao, Tema tema, string texto)
        {
            acao();
            CarregarTemas();
            CarregaMensagem(tema, texto);

            foreach (Item item in tema.Itens)
                item.Tema = tema;
        }
        #endregion
    }
}
