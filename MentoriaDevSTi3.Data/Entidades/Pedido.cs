using System.Collections.Generic;

namespace MentoriaDevSTi3.data.Entidades
{
    public class Pedido
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public string FormaPagamento { get; set; }
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
