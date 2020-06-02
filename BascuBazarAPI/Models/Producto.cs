using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Producto
    {
        [Key]
        [DisplayName("Codigo")]
        public int ProductoId { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public string Color { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

    }
}
