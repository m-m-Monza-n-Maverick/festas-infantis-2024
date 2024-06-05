namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class Festa (string rua, int numero, string bairro, string cidade, string estado, DateTime dataFesta, TimeSpan horaInicio, TimeSpan horaFim)
    {
        public string Rua { get; set; } = rua;
        public int Numero { get; set; } = numero;
        public string Bairro { get; set; } = bairro;
        public string Cidade { get; set; } = cidade;
        public string Estado { get; set; } = estado;
        public DateTime DataFesta { get; set; } = dataFesta;
        public TimeSpan HoraInicio { get; set; } = horaInicio;
        public TimeSpan HoraFim { get; set; } = horaFim;
        public string Endereço { get; set; } = $"Rua {rua}, Nº {numero}, Bairro {bairro}, {cidade}/{estado}";
    }
}