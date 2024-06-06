﻿using eAgenda.ConsoleApp.Compartilhado;

namespace FestasInfantis.WinApp.ModuloAluguel
{
    public class RepositorioAluguelEmMemoria : RepositorioBaseEmMemoria<Aluguel>, IRepositorioAluguel 
    {
        public decimal PorcentDesconto { get; set; }
        public decimal PorcentMaxDesconto { get; set; } = 0.3m;

        public List<Aluguel> SelecionarCompromissosPendentes()
            => registros
                .FindAll(aluguel => !aluguel.Concluido);

        public List<Aluguel> SelecionarCompromissosConcluidos()
            => registros
                .FindAll(aluguel => aluguel.Concluido);
    }
}
