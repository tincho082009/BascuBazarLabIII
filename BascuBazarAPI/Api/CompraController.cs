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
    public class CompraController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public CompraController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/Compra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> Get()
        {
            return Ok(contexto.Compra.Include(e => e.Usuario).ToList());
        }

        // GET: api/Compra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(contexto.Compra.Include(x=> x.Usuario).SingleOrDefault(x => x.CompraId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Compra
        [HttpPost]
        public async Task<IActionResult> Post(Compra entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioPrueba = User.Identity.Name;
                    int id = contexto.Usuario.Single(e => e.Email == usuarioPrueba).UsuarioId;
                    entidad.UsuarioId = id;
                    contexto.Compra.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.CompraId }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Compra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Compra entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.Compra.AsNoTracking().FirstOrDefault(e => e.CompraId == id) != null)
                {
                    entidad.CompraId = id;
                    contexto.Compra.Update(entidad);
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
                var entidad = contexto.Compra.FirstOrDefault(e => e.CompraId == id);
                if (entidad != null)
                {
                    contexto.Compra.Remove(entidad);
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
