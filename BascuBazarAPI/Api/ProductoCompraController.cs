using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BascuBazarAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BascuBazarAPI.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductoCompraController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public ProductoCompraController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/ProductoPedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoCompra>>> Get()
        {
            var user = User.Identity.Name;
            return Ok(contexto.ProductoCompra.Include(e=> e.Producto).Include(e=> e.Compra).Where(e=>e.Compra.Usuario.Email == user));
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
        public async Task<IActionResult> Post(ProductoCompra entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.ProductoCompra.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.ProductoCompraId }, entidad);
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
        public async Task<IActionResult> Put(int id, ProductoCompra entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.ProductoCompra.AsNoTracking().FirstOrDefault(e => e.ProductoCompraId == id) != null)
                {
                    entidad.ProductoCompraId = id;
                    contexto.ProductoCompra.Update(entidad);
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
                var entidad = contexto.ProductoCompra.FirstOrDefault(e => e.ProductoCompraId == id);
                if (entidad != null)
                {
                    contexto.ProductoCompra.Remove(entidad);
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
