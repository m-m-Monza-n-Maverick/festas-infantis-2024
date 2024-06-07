using FestasInfantis.WinApp.Compartilhado;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    internal class RepositorioAluguelEmArquivo : RepositorioBaseEmArquivo<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmArquivo() : base("alugueis.json")
        {
        }

        public decimal PorcentDesconto { get; set; }
        public decimal PorcentMaxDesconto { get; set; } = 0.3m;

        public List<Aluguel> SelecionarCompromissosPendentes()
            => registros
                .FindAll(aluguel => !aluguel.Concluido);

        public List<Aluguel> SelecionarCompromissosConcluidos()
            => registros
                .FindAll(aluguel => aluguel.Concluido);
    }
}
