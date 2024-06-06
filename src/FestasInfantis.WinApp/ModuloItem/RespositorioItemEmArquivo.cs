using FestasInfantis.WinApp.Compartilhado;


namespace FestasInfantis.WinApp.ModuloItem
{
    internal class RepositorioItemEmArquivo : RepositorioBaseEmArquivo<Item>, IRepositorioItem
    {
        public RepositorioItemEmArquivo() : base("Itens.json")
        {

        }
    }
}