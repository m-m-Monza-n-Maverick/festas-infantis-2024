using eAgenda.ConsoleApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class RepositorioAluguelEmMemoria : RepositorioBaseEmMemoria <Aluguel> 
    {
        public decimal PorcentDesconto { get; set; }
        public decimal PorcentMaxDesconto { get; set; } = 0.3m;

        internal List<Aluguel> SelecionarCompromissosPendentes()
            => registros
                .FindAll(aluguel => !aluguel.Concluido);

        internal List<Aluguel> SelecionarCompromissosConcluidos()
            => registros
                .FindAll(aluguel => aluguel.Concluido);
    }
}
