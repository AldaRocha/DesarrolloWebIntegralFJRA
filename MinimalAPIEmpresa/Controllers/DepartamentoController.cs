using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPIEmpresa.Models;

namespace MinimalAPIEmpresa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly MinimalContext _context;

        public DepartamentoController(MinimalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> Get()
        {
            return await _context.Departamento.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> Get(int id)
        {
            Departamento? departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return departamento;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Departamento departamento)
        {
            _context.Departamento.Add(departamento);
            await _context.SaveChangesAsync();
            return Ok(departamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Departamento departamento)
        {
            if (id != departamento.DepartamentoId)
            {
                return BadRequest();
            }

            _context.Entry(departamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Departamento? departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
