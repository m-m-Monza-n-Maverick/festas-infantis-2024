using eAgenda.ConsoleApp.Compartilhado;

namespace FestasInfantis.WinApp
{
    public class Cliente(string nome, string telefone, string cPF) : EntidadeBase
    {
        public string Nome { get; set; } = nome;
        
        public string Telefone { get; set; } = telefone;

        public string CPF { get; set; } = cPF;


        public override List<string> Validar()
        {

            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" è obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"Telefone\" è obrigatório");

            if (string.IsNullOrEmpty(CPF.Trim()))

                erros.Add("O campo \"CPF\" è obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Cliente atualizado = (Cliente)novoRegistro;

            Nome = atualizado.Nome;
            Telefone = atualizado.Telefone;
            CPF = atualizado.CPF;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}, Telefone: {Telefone}, CPF: {CPF}";
        }
    }
}