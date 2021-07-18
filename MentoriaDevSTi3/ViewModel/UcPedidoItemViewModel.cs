namespace Mentoria_STi3.ViewModel
{
    public class UcPedidoItemViewModel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnit { get; set; }
        public decimal ValorTotalItem { get; set; }
        public decimal ValorTotalPedido { get; set; }
        public long ProdutoId { get; set; }
    }
}
