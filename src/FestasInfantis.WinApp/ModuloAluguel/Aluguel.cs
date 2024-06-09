using eAgenda.ConsoleApp.Compartilhado;
namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {
        public Cliente Cliente { get; set; }
        public Tema Tema { get; set; }
        public decimal PorcentEntrada { get; set; }
        public Festa Festa { get; set; }
        public bool Concluido { get; set; } = false;
        public decimal PorcentDesconto { get; set; }
        public decimal ValorEntrada { get => Tema.Valor * PorcentEntrada; set { } }
        public decimal ValorTemaComDesconto { get => Tema.Valor * (1 - PorcentDesconto); set { } }
        public decimal ValorPendente 
        { 
            get
            {
                if (Concluido) return 0;
                return ValorTemaComDesconto - ValorEntrada;
            }
            set { } 
        }
        public DateTime DataPagam { get; set; }


        public Aluguel() { }
        public Aluguel(Cliente cliente, Tema tema, decimal porcentEntrada, decimal porcentDesconto, Festa festa)
        {
            Cliente = cliente;
            Tema = tema;
            PorcentEntrada = porcentEntrada;
            Festa = festa;
            PorcentDesconto = porcentDesconto;
        }


        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Aluguel atualizado = (Aluguel)novoRegistro;

            Cliente = atualizado.Cliente;
            Tema = atualizado.Tema;
            PorcentEntrada = atualizado.PorcentEntrada;
            Festa = atualizado.Festa;
            PorcentDesconto = atualizado.PorcentDesconto;
    }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Festa.HoraInicio, "horário de início da festa");
            VerificaNulo(ref erros, Festa.HoraFim, "horário de término da festa");
            VerificaNulo(ref erros, Festa.Cidade, "cidade");
            VerificaNulo(ref erros, Festa.Estado, "estado");
            VerificaNulo(ref erros, Festa.Rua, "rua");
            VerificaNulo(ref erros, Festa.Bairro, "bairro");
            VerificaNulo(ref erros, Festa.Numero, "número");
            VerificaNulo(ref erros, Cliente);
            VerificaNulo(ref erros, Tema);
            VerificaNulo(ref erros, PorcentEntrada, "sinal");

            return erros;
        }
        protected void VerificaNulo(ref List<string> erros, Cliente campoTestado)
        {
            if (campoTestado == null)
                erros.Add("\nÉ necessário informar um \"Cliente\". Tente novamente ");
            else if (campoTestado.Nome == "Não há clientes...")
                erros.Add("\nÉ necessário informar um \"Cliente\". Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, Tema campoTestado)
        {
            if (campoTestado == null)
                erros.Add("\nÉ necessário informar um \"Tema\". Tente novamente ");
            else if (campoTestado.Nome == "")
                erros.Add("\nÉ necessário informar um \"Tema\". Tente novamente ");
        }
        protected void VerificaNulo(ref List<string> erros, decimal campoTestado, string mostraCampo)
        {
            if (string.IsNullOrEmpty(campoTestado.ToString()) || campoTestado == 0)
                erros.Add($"\nO campo \"{mostraCampo}\" é obrigatório. Tente novamente ");
        }
    }
}