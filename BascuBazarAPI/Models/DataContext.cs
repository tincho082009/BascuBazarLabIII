using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BascuBazarAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ProductoPedido> ProductoPedido { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
    }
}
