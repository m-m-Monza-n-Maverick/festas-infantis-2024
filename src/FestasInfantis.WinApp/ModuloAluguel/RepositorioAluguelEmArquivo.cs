using FestasInfantis.WinApp.Compartilhado;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    internal class RepositorioAluguelEmArquivo : RepositorioBaseEmArquivo<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmArquivo(ContextoDados contexto) : base(contexto) {}

        public decimal PorcentDesconto { get; set; }
        public decimal PorcentMaxDesconto { get; set; } = 0.3m;

        public List<Aluguel> SelecionarCompromissosPendentes()
            => ObterRegistros()
                .FindAll(aluguel => !aluguel.Concluido);

        public List<Aluguel> SelecionarCompromissosConcluidos()
            => ObterRegistros()
                .FindAll(aluguel => aluguel.Concluido);

        protected override List<Aluguel> ObterRegistros() => contexto.Alugueis;
    }
}
