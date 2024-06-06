using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestasInfantis.WinApp.ModuloItem
{
    internal interface IRepositorioItem
    {
        void Cadastrar(Item novoItem);
        bool Editar(int id, Item itemEditado);
        bool Excluir(int id);
        Item SelecionarPorId(int idSelecionado);
        List<Item> SelecionarTodos();
    }
}