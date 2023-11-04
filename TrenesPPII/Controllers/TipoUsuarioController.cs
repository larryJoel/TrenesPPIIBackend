using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : Controller
    {
        private readonly TrenesContext _context;

        public TipoUsuarioController(TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("TipoUsuario")]
        public async Task<IActionResult> TipoUsuario()
        {
            var listUsuario = await _context.TipoUsuarios.ToListAsync();
            return Ok(listUsuario);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] TipoUsuario tipo)
        {
            await _context.TipoUsuarios.AddRangeAsync(tipo);
            await _context.SaveChangesAsync();
            return Ok(tipo);
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult> Editar(int id, [FromBody] TipoUsuario usuario)
        {
            var res = _context.TipoUsuarios.Find(id);
            if (res == null)
            {
                return BadRequest("No existe le tipo de usuario");
            }
            else
            {
                res.Nombre = usuario.Nombre;
                res.Desripcion = usuario.Desripcion;
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var res = _context.TipoUsuarios.Find(id);
            if(res == null)
            {
                return BadRequest("No existe el tipo de usuario");
            }
            else
            {
                _context.TipoUsuarios.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }
    }
}
