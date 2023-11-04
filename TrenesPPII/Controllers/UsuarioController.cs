using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TrenesPPII.data;
using TrenesPPII.Models;

namespace TrenesPPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TrenesContext _context;

        public UsuarioController(TrenesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Usuario")]
        public async Task<IActionResult> Usuarios()
        {
            var listaUser = await _context.Usuarios.ToListAsync();
            return Ok(listaUser);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Usuario request)
        {
            await _context.Usuarios.AddAsync(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpDelete]
        [Route("Eliminar/id:int")]
        public async Task<IActionResult>Eliminar(int id)
        {
            var res = await _context.Usuarios.FindAsync(id);
            if (res == null)
            {
                return BadRequest("Usuario no existe");
            }
            else
            {
                _context.Usuarios.Remove(res);
                await _context.SaveChangesAsync();
                return Ok(res);
            }
        }

        [HttpPut]
        [Route("Editar/id:int")]
        public async Task<IActionResult>Editar(int id, [FromBody] Usuario request)
        {
            var user = _context.Usuarios.Find(id);
            if(user == null)
            {
                return BadRequest("Usuario no existe");
            }
            else
            {
                user.Nombre = request.Nombre;
                user.Apellido = request.Apellido;
                user.Direccion = request.Direccion;
                user.Cp = request.Cp;
                user.TipoDocId = request.TipoDocId;
                user.NroDocumento = request.NroDocumento;
                user.Telefono = request.Telefono;
                user.Email = request.Email;
                user.TipoUsuario = request.TipoUsuario;
                user.FechaIni = request.FechaIni;
                user.FechaEdit = request.FechaEdit;
                //user.IrolId = request.IrolId;
                await _context.SaveChangesAsync();
                return Ok(user);
            }

        }
    }
}
