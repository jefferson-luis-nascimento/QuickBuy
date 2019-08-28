using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public override void Validate()
        {
            base.Validate();

            if (string.IsNullOrWhiteSpace(Senha))
                AdicionarCritica("Critica - Senha do usuario deve ser informado.");

            if (string.IsNullOrWhiteSpace(Email))
                AdicionarCritica("Critica - Email do usuario deve ser informado.");
        }
    }
}
