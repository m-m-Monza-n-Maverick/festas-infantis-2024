namespace FestasInfantis.WinApp.ModuloTema
{
    internal interface IRepositorioTema
    {
        void Cadastrar(Tema novoTema);
        bool Editar(int id, Tema temaEditado);
        bool Excluir(int id);
        Tema SelecionarPorId(int idSelecionado);
        List<Tema> SelecionarTodos();
    }
}