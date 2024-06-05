using eAgenda.ConsoleApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class Aluguel (Cliente cliente, Tema tema, decimal porcentEntrada, Festa festa) : EntidadeBase
    {
        public Cliente Cliente { get; set; } = cliente;
        public Tema Tema { get; set; } = tema;
        public decimal PorcentEntrada { get; set; } = porcentEntrada;
        public DateTime DataPagam { get; set; }
        public bool Status { get; set; }
        public Festa Festa { get; set; } = festa;
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
            List<string> erros = [];

            VerificaNulo(ref erros, Festa.Rua, "rua");
            VerificaNulo(ref erros, Festa.Numero, "número");
            VerificaNulo(ref erros, Festa.Bairro, "bairro");
            VerificaNulo(ref erros, Festa.Cidade, "cidade");
            VerificaNulo(ref erros, Festa.Estado, "estado");
            VerificaNulo(ref erros, Cliente);
            VerificaNulo(ref erros, Tema);
            VerificaNulo(ref erros, PorcentEntrada, "sinal");

            return erros;
        }
        protected void VerificaNulo(ref List<string> erros, Cliente campoTestado)
        {
            if (campoTestado == null)
                erros.Add("\nÉ necessário informar um \"Cliente\". Tente novamente ");
            else if (campoTestado.Nome == "")
                erros.Add("\nÉ necessário informar um \"Cliente\". Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, Tema campoTestado)
        {
            if (campoTestado == null)
                erros.Add("\nÉ necessário informar um \"Tema\". Tente novamente ");
            else if (campoTestado.Nome == "não cadastrado..........")
                erros.Add("\nÉ necessário informar um \"Tema\". Tente novamente ");
        }
    }
}