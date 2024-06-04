using eAgenda.ConsoleApp.Compartilhado;
using FestasInfantis.WinApp.ModuloItem;
namespace FestasInfantis.WinApp
{
    public class Tema (string nome, List<Item> itens) : EntidadeBase
    {
        private int valor { get; set; }
        public string Nome { get; set; } = nome;
        public List<Item> Itens { get; set; } = itens;
        public int Valor 
        {
            get 
            {
                valor = 0;

                foreach (Item item in Itens)
                    valor += item.Valor;

                return valor;
            }
            set => valor = value;
        }


        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Tema atualizado = (Tema)novoRegistro;

            Nome = atualizado.Nome;
            Itens = atualizado.Itens;
            Valor = atualizado.Valor;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Nome, "nome");

            return erros;
        }
    }
}