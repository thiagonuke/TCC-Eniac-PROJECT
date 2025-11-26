using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UrbanFarming.Domain.Classes
{
    public class ItensPedido
    {
        public int CodigoPedido { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

    }
}
