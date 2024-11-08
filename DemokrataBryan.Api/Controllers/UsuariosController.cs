using DemokrataBryan.Business.Interfaces;
using DemokrataBryan.Entities;
using DemokrataBryan.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemokrataBryan.Api.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosBL _usuariosBL;

        public UsuariosController(IUsuariosBL usuariosBL)
        {
            _usuariosBL = usuariosBL;
        }

        // GET: api/Usuarios/{id}
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var output = await _usuariosBL.GetById(id);

            if (output.error)
            {
                return BadRequest(output);
            }

            if (!output.success)
            {
                return NotFound(output);
            }

            return Ok(output);
        }

        // GET: api/Usuarios?nombre=Juan&apellido=Perez&page=1&pageSize=10
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(string nombre = "", string apellido = "", int page = 1, int pageSize = 10)
        {
            var output = await _usuariosBL.GetUsers(nombre, apellido, page, pageSize);

            if (output.error)
            {
                return BadRequest(output);
            }

            return Ok(output);
        }

        // POST: api/Usuarios
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioDto usuarioDto)
        {
            var output = await _usuariosBL.Create(usuarioDto);
            if (output.error)
            {
                return BadRequest(output);
            }

            return Created("Create", output);
        }

        // PUT: api/Usuarios/{id}
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto usuarioDto)
        {
            var output = await _usuariosBL.Update(id, usuarioDto);

            if (output.error)
            {
                return BadRequest(output);
            }

            if (!output.success)
            {
                return NotFound(output);
            }

            return NoContent();
        }

        // DELETE: api/Usuarios/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var output = await _usuariosBL.Delete(id);

            if (output.error)
            {
                return BadRequest(output);
            }

            if (!output.success)
            {
                return NotFound(output);
            }

            return NoContent();
        }
    }
}
