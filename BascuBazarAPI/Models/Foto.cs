using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Foto
    {
        [Key]
        [DisplayName("Codigo")]
        public int FotoId { get; set; }
        public string Url { get; set; }
        public string Tipo { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }
    }
}
