using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPIEmpresa.Models;

namespace MinimalAPIEmpresa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly MinimalContext _context;

        public EmpleadoController(MinimalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> Get()
        {
            return await _context.Empleado.Include(p => p.Ciudad).Include(p => p.EmpleadoDepartamentos).ThenInclude(p => p.Departamento).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> PostEmpleadoConDepartamentos(EmpleadoDto empleadoDto)
        {
            Empleado empleado = new Empleado
            {
                Nombre = empleadoDto.Nombre,
                FechaIngreso = empleadoDto.FechaIngreso,
                Puesto = empleadoDto.Puesto,
                Sueldo = empleadoDto.Sueldo,
                CiudadId = empleadoDto.CiudadId,
                EmpleadoDepartamentos = empleadoDto.DepartamentoIds.Select(p => new EmpleadoDepartamento { DepartamentoId = p }).ToList()
            };

            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Empleado empleado)
        {
            if (id != empleado.EmpleadoId)
            {
                return BadRequest();
            }

            Empleado? emp = await _context.Empleado.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            emp.Nombre = empleado.Nombre;
            emp.FechaIngreso = empleado.FechaIngreso;
            emp.Puesto = empleado.Puesto;
            emp.Sueldo = empleado.Sueldo;
            empleado.CiudadId = empleado.CiudadId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            Empleado? empleado = await _context.Empleado.Include(p => p.EmpleadoDepartamentos).FirstOrDefaultAsync(p => p.EmpleadoId == id);

            if (empleado == null)
            {
                return NotFound();
            }

            _context.EmpleadoDepartamento.RemoveRange(empleado.EmpleadoDepartamentos);
            _context.Empleado.Remove(empleado);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
