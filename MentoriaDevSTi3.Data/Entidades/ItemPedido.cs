namespace MentoriaDevSTi3.data.Entidades
{
    public class ItemPedido
    {
        public long Id { get; set; }
        public long PedidoId { get; set; }
        public long ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Pedido Pedidos { get; set; }
        public Produto Produtos { get; set; }
    }
}
