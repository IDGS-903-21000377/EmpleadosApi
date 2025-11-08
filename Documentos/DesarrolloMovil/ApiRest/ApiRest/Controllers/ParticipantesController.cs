using ApiRest.Data;
using ApiRest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParticipantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantesController(AppDbContext context)
        {
            _context = context;
        }
        // /api/listado/all -> devuelve todos (GET explícito)
        [HttpGet("listado/all")]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _context.Participantes.ToListAsync();
            return Ok(lista);
        }



        //  /api/listado (con o sin búsqueda)
        [HttpGet("listado")]
        public async Task<IActionResult> GetListado([FromQuery] string? q)
        {
            var query = _context.Participantes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(p => p.Nombre.Contains(q) || p.Email.Contains(q));
            }

            var lista = await query.ToListAsync();
            return Ok(lista);
        }

        //  /api/participante/:id
        [HttpGet("participante/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null)
                return NotFound("Participante no encontrado");

            return Ok(participante);
        }

        [HttpPost("registro")]
        public async Task<IActionResult> RegistrarParticipante([FromBody] Participante participante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Participante registrado" });
        }


        // DELETE: api/participantes/eliminar/5
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);

            if (participante == null)
                return NotFound(new { message = "No existe el participante" });

            _context.Participantes.Remove(participante);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Participante eliminado correctamente" });
        }


    }

        }
