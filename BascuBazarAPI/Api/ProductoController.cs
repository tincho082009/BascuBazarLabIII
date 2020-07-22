using System;
using System.Collections;
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
    public class ProductoController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public ProductoController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> Get()
        {
            try
            {
                return Ok(contexto.Producto.Include(x=> x.Categoria));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Producto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(contexto.Producto.Include(x=>x.Categoria).SingleOrDefault(x => x.ProductoId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //GET: api/Producto/search/{categoriaId}
        [HttpGet("search/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosPorCategoria(int categoriaId)
        {
            try
            {
                return Ok(contexto.Producto.Include(x => x.Categoria).Where(x => x.CategoriaId == categoriaId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //GET: api/Producto/search/descripcion/{descripcion}
        [HttpGet("search/descripcion/{descripcion}")]
        public async Task<IActionResult> GetProductosPorDescripcion(string descripcion)
        {
            try
            {
                return Ok(contexto.Producto.SingleOrDefault(x => x.Descripcion.Equals(descripcion)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Producto
        [HttpPost]
        public async Task<IActionResult> Post(Producto entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Producto.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.ProductoId }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Producto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.Producto.AsNoTracking().FirstOrDefault(e => e.ProductoId == id) != null)
                {
                    entidad.ProductoId = id;
                    contexto.Producto.Update(entidad);
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
                var entidad = contexto.Producto.FirstOrDefault(e => e.ProductoId == id);
                if (entidad != null)
                {
                    contexto.Producto.Remove(entidad);
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
