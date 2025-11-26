using System;
using System.Collections.Generic;

namespace AppMobileUrban.Models
{
    public class Pedido
    {
        public int CodigoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }
        public List<ItensPedido> Itens { get; set; }

        public Pedido()
        {

            Itens = new List<ItensPedido>();
        }
    }
}
