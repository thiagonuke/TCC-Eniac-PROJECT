using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UrbanFarming.Domain.Classes
{
    public class Pedido
    {
        [Key]
        public int CodigoPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string Usuario { get; set; }
        public DateTime Data { get; set; }
        [NotMapped]
        public List<ItensPedido> Itens { get; set; }

        public Pedido() { 
        
        Itens = new List<ItensPedido>(); 
        }
    }
}
