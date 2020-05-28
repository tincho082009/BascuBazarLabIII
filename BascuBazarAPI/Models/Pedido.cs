using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Pedido
    {
        [Key]
        [DisplayName("Codigo")]
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public int UsuarioId { get; set; }
        public bool Estado { get; set; }
    }
}
