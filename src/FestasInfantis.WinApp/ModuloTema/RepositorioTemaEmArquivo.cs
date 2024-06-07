using FestasInfantis.WinApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloTema
{
    internal class RepositorioTemaEmArquivo : RepositorioBaseEmArquivo<Tema>, IRepositorioTema
    {
        public RepositorioTemaEmArquivo() : base("temas.json")
        {

        }
    }
}