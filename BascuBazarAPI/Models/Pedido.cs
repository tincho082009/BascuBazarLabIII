using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Pedido
    {
        [Key]
        [DisplayName("Codigo")]
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
        public bool Estado { get; set; }
    }
}
