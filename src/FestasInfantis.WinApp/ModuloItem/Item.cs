using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.WinApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloItem
{
    public class Item(string descricao, int valor) : EntidadeBase
    {
        public string Descricao { get; set; } = descricao;
        public int Valor { get; set; } = valor;
        public Tema Tema { get; set; }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Item atualizado = (Item)novoRegistro;

            Descricao = atualizado.Descricao;
            Valor = atualizado.Valor;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Descricao, "descrição");
            VerificaNulo(ref erros, Valor, "valor");

            return erros;
        }
        public override string ToString()
        {
            return $"Id: {Id}, " +
                   $"Descrição: {Descricao.ToTitleCase()}, " +
                   $"Valor: {Valor}";
        }
    }
}