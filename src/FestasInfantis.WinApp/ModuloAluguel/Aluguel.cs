using eAgenda.ConsoleApp.Compartilhado;
using System.Drawing;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class Aluguel (Cliente cliente, Tema tema, decimal porcentEntrada) : EntidadeBase
    {
        public Cliente Cliente { get; set; } = cliente;
        public Tema Tema { get; set; } = tema;
        public decimal PorcentEntrada { get; set; } = porcentEntrada;
        public DateTime DataPagam { get; set; }
        public bool Status { get; set; }
        public Festa Festa { get; set; }
        public int PorcentDesconto { get; set; }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Aluguel atualizado = (Aluguel)novoRegistro;

            Cliente = atualizado.Cliente;
            Tema = atualizado.Tema;
            PorcentEntrada = atualizado.PorcentEntrada;
        }
        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}