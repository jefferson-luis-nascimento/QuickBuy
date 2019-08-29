namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }

        public override void Validate()
        {
            base.Validate();

            if (ProdutoId == 0)
                AdicionarCritica("Não foi informado o produto.");

            if (PedidoId == 0)
                AdicionarCritica("Pedido nãi informado.");

            if (Quantidade == 0)
                AdicionarCritica("Não foi informado a Quantidade.");
        }
    }
}
