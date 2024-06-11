using FestasInfantis.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloAluguel;
namespace FestasInfantis.WinApp.ModuloCliente
{
    internal class RepositorioClienteEmArquivo : RepositorioBaseEmArquivo<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmArquivo(ContextoDados contexto) : base(contexto) { }

        protected override List<Cliente> ObterRegistros() => contexto.Clientes;
    }
}