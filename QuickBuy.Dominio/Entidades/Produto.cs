using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (string.IsNullOrWhiteSpace(Nome))
                AdicionarCritica("Critica - Nome do produto deve ser informado.");

            if (string.IsNullOrWhiteSpace(Descricao))
                AdicionarCritica("Critica - Descrição do produto deve ser informado.");

        }
    }
}
