using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class Categoria
    {
        [Key]
        [DisplayName("Codigo")]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
    }
}
