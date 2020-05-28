using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Producto_Pedido
    {
        [Key]
        [DisplayName("Codigo")]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
    }
}
