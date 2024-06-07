namespace eAgenda.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBaseEmMemoria<T> where T : EntidadeBase
    {
        protected List<T> registros = [];
        protected int contadorId = 1;


        public void Cadastrar(T novoRegistro)
        {
            novoRegistro.Id = contadorId++;
            registros.Add(novoRegistro);
        }
        public bool Editar(int id, T novaEntidade)
        {
            T registro = SelecionarPorId(id);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(novaEntidade);
            return true;
        }
        public bool Excluir(int id) => registros.Remove(SelecionarPorId(id));


        public List<T> SelecionarTodos()
        {
            return registros;
        }
        public T SelecionarPorId(int id) => registros.Find(x => x.Id == id);
        public int PegarId() => contadorId;
    }
}
