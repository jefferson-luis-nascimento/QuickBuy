﻿using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();

        public override void Validate()
        {
            base.Validate();

            if (ItensPedido.Any())
                AdicionarCritica("Crítica - Pedido não pode ficar sem itens de Pedido.");

            if (string.IsNullOrWhiteSpace(Cep))
                AdicionarCritica("Crítica - CEP deve estar preenchido.");
        }
    }
}
