﻿using eAgenda.ConsoleApp.Compartilhado;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FestasInfantis.WinApp.Compartilhado
{
    internal abstract class RepositorioBaseEmArquivo<T>(ContextoDados contexto) where T : EntidadeBase
    {
        protected int contadorId //Baseado no Id do último item cadastrado
        {
            get
            {
                if (backupId != 0) return backupId;
                if (ObterRegistros().Count != 0) return ObterRegistros().Last().Id + 1;
                return 1;
            }
            set { }
        }
        protected int backupId; //Caso o último registro seja excluído
        protected abstract List<T> ObterRegistros();
        protected ContextoDados contexto = contexto;

        public void Cadastrar(T novoRegistro)
        {
            novoRegistro.Id = contadorId++;
            backupId = 0;

            ObterRegistros().Add(novoRegistro);

            contexto.Gravar();
        }
        public bool Editar(int id, T novaEntidade)
        {
            T registro = SelecionarPorId(id);

            if (registro == null)
                return false;

            registro.AtualizarRegistro(novaEntidade);

            contexto.Gravar();

            return true;
        }
        public bool Excluir(int id)
        {
            if (SelecionarPorId(id) == ObterRegistros().Last()) backupId = contadorId;

            bool conseguiuExcluir = ObterRegistros().Remove(SelecionarPorId(id));

            if (!conseguiuExcluir) return false;

            contexto.Gravar();

            return true;
        }


        public List<T> SelecionarTodos() => ObterRegistros();
        public T SelecionarPorId(int id) => ObterRegistros().Find(x => x.Id == id);
        public int PegarId() => contadorId;
        public bool Existe(int id) => ObterRegistros().Any(x => x.Id == id);
    }
}