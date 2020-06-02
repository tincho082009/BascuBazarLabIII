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
    public class CategoriaController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public CategoriaController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/Categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            try
            {
                return Ok(contexto.Categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(contexto.Categoria.SingleOrDefault(x => x.CategoriaId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
         
            }
        }

        // POST: api/Categoria
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Post(Categoria entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contexto.Categoria.Add(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.CategoriaId }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Categoria entidad)
        {
            try
            {
                if (ModelState.IsValid && contexto.Categoria.AsNoTracking().FirstOrDefault(e => e.CategoriaId == id) != null)
                {
                    entidad.CategoriaId = id;
                    contexto.Categoria.Update(entidad);
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
                var entidad = contexto.Categoria.FirstOrDefault(e => e.CategoriaId == id);
                if (entidad != null)
                {
                    contexto.Categoria.Remove(entidad);
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
