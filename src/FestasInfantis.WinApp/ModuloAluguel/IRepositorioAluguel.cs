namespace FestasInfantis.WinApp.ModuloAluguel
{
    public interface IRepositorioAluguel
    {
        decimal PorcentDesconto { get; set; }
        decimal PorcentMaxDesconto { get; set; }

        void Cadastrar(Aluguel novoAluguel);
        bool Editar(int id, Aluguel aluguelEditado);
        bool Excluir(int id);


        Aluguel SelecionarPorId(int idSelecionado);
        List<Aluguel> SelecionarTodos();
        int PegarId();
        List<Aluguel> SelecionarCompromissosPendentes();
        List<Aluguel> SelecionarCompromissosConcluidos();
        void Atualizar();
    }
}
