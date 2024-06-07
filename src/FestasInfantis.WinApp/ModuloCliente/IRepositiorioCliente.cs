namespace FestasInfantis.WinApp.ModuloCliente
{
    public interface IRepositorioCliente
    {
        void Cadastrar(Cliente novoCliente);
        bool Editar(int id, Cliente clienteEditado);
        bool Excluir(int id);


        Cliente SelecionarPorId(int idSelecionado);
        List<Cliente> SelecionarTodos();
        int PegarId();
    }
}