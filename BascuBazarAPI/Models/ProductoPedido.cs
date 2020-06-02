using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class ProductoPedido
    {
        [Key]
        [DisplayName("Codigo")]
        public int ProductoPedidoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }
        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }
    }
}
