using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Pagos
    {
        [Key]
        [DisplayName("Codigo")]
        public int PagoId { get; set; }
        [DisplayName("Numero de pago")]
        public int NroPago { get; set; }
        [DisplayName("Fecha de pago"), DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
        public decimal Precio { get; set; }
        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public Pedido ContratoAlquiler { get; set; }
    }
}
