using eAgenda.ConsoleApp.Compartilhado;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FestasInfantis.WinApp.Compartilhado
{
    internal class RepositorioBaseEmArquivo<T> where T : EntidadeBase
    {
        protected int contadorId //Baseado no Id do último item cadastrado
        {
            get
            {
                if (backupId != 0) return backupId;
                if (registros.Count != 0) return registros.Last().Id + 1;
                return 1;
            }
            set { }
        }
        protected int backupId; //Caso o último registro seja excluído
        protected List<T> registros = [];
        private string caminho = string.Empty;

        public RepositorioBaseEmArquivo(string nomeArquivo)
        {
            caminho = $"C:\\temp\\FestasInfantis\\{nomeArquivo}";

            registros = DeserializarRegistros();
        }


        public void Cadastrar(T novoRegistro)
        {
            novoRegistro.Id = contadorId++;
            backupId = 0;

            registros.Add(novoRegistro);

            SerializarRegistros();
        }
        public bool Editar(int id, T novaEntidade)
        {
            T registro = SelecionarPorId(id);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(novaEntidade);

            SerializarRegistros();

            return true;
        }
        public bool Excluir(int id)
        {
            if (SelecionarPorId(id) == registros.Last()) backupId = contadorId;

            bool conseguiuExcluir = registros.Remove(SelecionarPorId(id));

            if (!conseguiuExcluir) return false;

            SerializarRegistros();

            return true;
        }


        public List<T> SelecionarTodos() => registros;
        public T SelecionarPorId(int id) => registros.Find(x => x.Id == id);
        public int PegarId() => contadorId;
        public bool Existe(int id) => registros.Any(x => x.Id == id);

        #region JSON
        protected void SerializarRegistros()
        {
            FileInfo arquivo = new(caminho);

            arquivo.Directory.Create();

            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            byte[] resgistrosEmBytes = JsonSerializer.SerializeToUtf8Bytes(registros, options);

            File.WriteAllBytes(caminho, resgistrosEmBytes);
        }
        protected List<T> DeserializarRegistros()
        {
            FileInfo arquivo = new FileInfo(caminho);

            if (!arquivo.Exists)
                return new List<T>();

            byte[] registrosEmBytes = File.ReadAllBytes(caminho);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNameCaseInsensitive = true
            };

            List<T> registros = JsonSerializer.Deserialize<List<T>>(registrosEmBytes, options);

            return registros;
        }
        #endregion
    }
}