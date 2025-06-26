using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinimalAPIEmpresa;
using MinimalAPIEmpresa.Models;

namespace MinimalAPIEmpresa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioModelsController : ControllerBase
    {
        private readonly MinimalContext _context;

        public UsuarioModelsController(MinimalContext context)
        {
            _context = context;
        }

        // GET: UsuarioModels
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> Index()
        {
            return Ok(await _context.UsuarioModel.ToListAsync());
        }

        // POST: UsuarioModels/Create
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return Ok(usuarioModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
