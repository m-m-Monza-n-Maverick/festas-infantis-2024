using FestasInfantis.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloAluguel;
namespace FestasInfantis.WinApp.ModuloItem
{
    internal class RepositorioItemEmArquivo : RepositorioBaseEmArquivo<Item>, IRepositorioItem
    {
        public RepositorioItemEmArquivo(ContextoDados contexto) : base(contexto) { }

        protected override List<Item> ObterRegistros() => contexto.Itens;
    }
}