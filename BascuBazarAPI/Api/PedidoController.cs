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
    public class PedidoController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public PedidoController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            return Ok(contexto.Pedido.Include(e => e.Usuario).ToList());
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(contexto.Pedido.Include(x=> x.Usuario).SingleOrDefault(x => x.PedidoId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Pedido
        [HttpPost]
        public async Task<IActionResult> Post(Pedido entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Pedido.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.PedidoId }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Pedido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pedido entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.Pedido.AsNoTracking().FirstOrDefault(e => e.PedidoId == id) != null)
                {
                    entidad.PedidoId = id;
                    contexto.Pedido.Update(entidad);
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
                var entidad = contexto.Pedido.FirstOrDefault(e => e.PedidoId == id);
                if (entidad != null)
                {
                    contexto.Pedido.Remove(entidad);
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
