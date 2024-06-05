namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class Festa (string rua, string numero, string bairro, string cidade, string estado, DateTime dataFesta, TimeSpan horaInicio, TimeSpan horaFim)
    {
        public string Rua { get; set; } = rua;
        public string Numero { get; set; } = numero;
        public string Bairro { get; set; } = bairro;
        public string Cidade { get; set; } = cidade;
        public string Estado { get; set; } = estado;
        public DateTime DataFesta { get; set; } = dataFesta;
        public TimeSpan HoraInicio { get; set; } = horaInicio;
        public TimeSpan HoraFim { get; set; } = horaFim;
        public string Endereço { get; set; } = $"Rua {rua}, Nº {numero}, Bairro {bairro}, {cidade}/{estado}";

        public override string ToString() => $"Dia {DataFesta:d} de: {HoraInicio:hh\\:mm} à {HoraFim:hh\\:mm}, {Endereço}";
    }
}