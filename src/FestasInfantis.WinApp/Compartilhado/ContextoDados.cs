using FestasInfantis.WinApp.ModuloAluguel;
using FestasInfantis.WinApp.ModuloItem;
using System.Text.Json.Serialization;
using System.Text.Json;
namespace FestasInfantis.WinApp.Compartilhado
{
    public class ContextoDados()
    {
        public List<Cliente> Clientes { get; set; } = [];
        public List<Item> Itens { get; set; } = [];
        public List<Tema> Temas { get; set; } = [];
        public List<Aluguel> Alugueis { get; set; } = [];
        private string caminho = $"C:\\temp\\FestasInfantis\\dados.json";

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados) CarregarDados();
        }

        public void Gravar()
        {
            FileInfo arquivo = new(caminho);

            arquivo.Directory.Create();

            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            byte[] resgistrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(this, options);

            File.WriteAllBytes(caminho, resgistrosEmBytes);
        }
        public void CarregarDados()
        {
            FileInfo arquivo = new (caminho);

            if (!arquivo.Exists) return;

            byte[] registrosEmBytes = File.ReadAllBytes(caminho);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosEmBytes, options);

            if (ctx == null) return;

            Clientes = ctx.Clientes;
            Itens = ctx.Itens;
            Temas = ctx.Temas;
            Alugueis = ctx.Alugueis;
        }
    }
}
