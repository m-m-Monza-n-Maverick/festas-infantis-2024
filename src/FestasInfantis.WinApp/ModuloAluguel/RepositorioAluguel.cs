using eAgenda.ConsoleApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class RepositorioAluguel : RepositorioBase <Aluguel> 
    {
        public decimal PorcentDesconto { get; set; }
        public decimal PorcentMaxDesconto { get; set; } = 0.3m;
    }
}
