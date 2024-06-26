﻿using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.WinApp.Compartilhado;
using FestasInfantis.WinApp.ModuloItem;
namespace FestasInfantis.WinApp
{
    public class Tema  : EntidadeBase
    {
        private int valor { get; set; }
        public string Nome { get; set; } 
        public List<Item> Itens { get; set; } 
        public int Valor 
        {
            get 
            {
                valor = 0;

                foreach (Item item in Itens)
                    valor += item.Valor;

                return valor;
            }
            set => valor = value;
        }
        public Tema()
        {
            
        }

        public Tema(string nome, List<Item> itens)
        {
            Nome = nome;
            Itens = itens;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Tema atualizado = (Tema)novoRegistro;

            Nome = atualizado.Nome;
            Itens = atualizado.Itens;
            Valor = atualizado.Valor;
        }
        public override List<string> Validar()
        {
            List<string> erros = [];

            VerificaNulo(ref erros, Nome, "nome");

            return erros;
        }
        public override string ToString()
        {
            if (Nome == "") return "Não há temas...";
            return $"{Nome.ToTitleCase()}, Valor: {Valor}";
        } 
    }
}