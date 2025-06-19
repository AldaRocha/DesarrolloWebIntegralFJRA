using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalAPIEmpresa.Models;

namespace MinimalAPIEmpresa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadController : ControllerBase
    {
        private readonly MinimalContext _context;

        public CiudadController(MinimalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ciudad>>> Get()
        {
            return await _context.Ciudad.ToListAsync();
        }
    }
}
