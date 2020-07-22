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
    public class FotoController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public FotoController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/Foto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Foto>>> Get()
        {
            try
            {
                return Ok(contexto.Foto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Foto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Foto>>> Get(int id)
        {
            try
            {
                return Ok(contexto.Foto.Include(x => x.Producto).Where(x => x.ProductoId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Foto
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Foto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
