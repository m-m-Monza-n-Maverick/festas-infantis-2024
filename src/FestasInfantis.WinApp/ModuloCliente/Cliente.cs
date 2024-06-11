using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloAluguel;

namespace FestasInfantis.WinApp
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; } 
        public string Telefone { get; set; } 
        public string CPF { get; set; } 
        public int AlugueisConcluidos 
        {
            get => Alugueis.FindAll(x => x.Concluido).Count;
            set { }
        }
        public List<Aluguel> Alugueis { get; set; } = [];

        public Cliente() { }
        public Cliente(string nome, string telefone, string cPF)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cPF;
        }

        public override List<string> Validar()
        {

            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"Telefone\" é obrigatório");

            if (CPF.Length != 11)
                erros.Add("O campo \"CPF\" está incorreto");

            if (Telefone.Length != 11)
                erros.Add("O campo \"Telefone\" está incorreto");

            if (string.IsNullOrEmpty(CPF.Trim()))
                erros.Add("O campo \"CPF\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Cliente atualizado = (Cliente)novoRegistro;

            Nome = atualizado.Nome;
            Telefone = atualizado.Telefone;
            CPF = atualizado.CPF;
        }

        public override string ToString() => $"{Nome.ToTitleCase()}";
    }
}