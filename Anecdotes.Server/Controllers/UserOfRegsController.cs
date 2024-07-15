using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Anecdotes.Server.Data;
using Anecdotes.Server.Models;

namespace Anecdotes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOfRegsController : ControllerBase
    {
        private readonly AppAnecdotasDbContext _context;

        public UserOfRegsController(AppAnecdotasDbContext context)
        {
            _context = context;
        }

        // GET: api/UserOfRegs
        // Este método obtiene una lista de todos los usuarios registrados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOfReg>>> GetUsuarioRegistrado()
        {
            return await _context.UsuarioRegistrado.ToListAsync();
        }

        // GET: api/UserOfRegs/5
        // Este método obtiene un usuario registrado específico por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOfReg>> GetUserOfReg(int id)
        {
            var userOfReg = await _context.UsuarioRegistrado.FindAsync(id);

            if (userOfReg == null)
            {
                return NotFound();
            }

            return userOfReg;
        }

        // PUT: api/UserOfRegs/5
        // Este método actualiza un usuario registrado específico por su ID
        // Protege contra ataques de sobrepublicación
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOfReg(int id, UserOfReg userOfReg)
        {
            if (id != userOfReg.Id)
            {
                return BadRequest();
            }

            _context.Entry(userOfReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOfRegExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserOfRegs
        // Este método crea un nuevo usuario registrado
        // Protege contra ataques de sobrepublicación
        [HttpPost]
        public async Task<ActionResult<UserOfReg>> PostUserOfReg(UserOfReg userOfReg)
        {
            _context.UsuarioRegistrado.Add(userOfReg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOfReg", new { id = userOfReg.Id }, userOfReg);
        }

        // DELETE: api/UserOfRegs/5
        // Este método elimina un usuario registrado específico por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOfReg(int id)
        {
            var userOfReg = await _context.UsuarioRegistrado.FindAsync(id);
            if (userOfReg == null)
            {
                return NotFound();
            }

            _context.UsuarioRegistrado.Remove(userOfReg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Este método verifica si un usuario registrado existe por su ID
        private bool UserOfRegExists(int id)
        {
            return _context.UsuarioRegistrado.Any(e => e.Id == id);
        }
    }
}
