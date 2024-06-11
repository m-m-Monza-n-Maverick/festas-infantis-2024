using FestasInfantis.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloAluguel;
namespace FestasInfantis.WinApp.ModuloTema
{
    internal class RepositorioTemaEmArquivo : RepositorioBaseEmArquivo<Tema>, IRepositorioTema
    {
        public RepositorioTemaEmArquivo(ContextoDados contexto) : base(contexto) { }

        protected override List<Tema> ObterRegistros() => contexto.Temas;
    }
}