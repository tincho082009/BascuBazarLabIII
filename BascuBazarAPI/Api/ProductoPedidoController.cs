using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BascuBazarAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BascuBazarAPI.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoPedidoController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public ProductoPedidoController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/ProductoPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoPedido>>> Get()
        {

            return Ok(contexto.ProductoPedido.Include(e=> e.Producto).Include(e=> e.Pedido).ToList());
        }

        // GET: api/ProductoPedido/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(contexto.Producto.SingleOrDefault(x => x.ProductoId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/ProductoPedido
        [HttpPost]
        public async Task<IActionResult> Post(ProductoPedido entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.ProductoPedido.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.ProductoPedidoId }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/ProductoPedido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductoPedido entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.ProductoPedido.AsNoTracking().FirstOrDefault(e => e.ProductoPedidoId == id) != null)
                {
                    entidad.ProductoPedidoId = id;
                    contexto.ProductoPedido.Update(entidad);
                    contexto.SaveChanges();
                    return Ok(entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entidad = contexto.ProductoPedido.FirstOrDefault(e => e.ProductoPedidoId == id);
                if (entidad != null)
                {
                    contexto.ProductoPedido.Remove(entidad);
                    contexto.SaveChanges();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
