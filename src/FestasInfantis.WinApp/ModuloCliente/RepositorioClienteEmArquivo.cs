using FestasInfantis.WinApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloCliente
{
    internal class RepositorioClienteEmArquivo : RepositorioBaseEmArquivo<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteEmArquivo() : base("clientes.json")
        {

        }
    }
}