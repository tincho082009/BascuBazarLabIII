using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Foto
    {
        [Key]
        [DisplayName("Codigo")]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
