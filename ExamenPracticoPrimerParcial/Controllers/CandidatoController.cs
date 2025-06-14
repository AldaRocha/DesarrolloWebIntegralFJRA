using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenPracticoPrimerParcial.Data;
using ExamenPracticoPrimerParcial.Models;

namespace ExamenPracticoPrimerParcial.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ExamenPracticoPrimerParcialContext _context;

        public CandidatoController(ExamenPracticoPrimerParcialContext context)
        {
            _context = context;
        }

        // GET: Candidato
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidato.ToListAsync());
        }

        // GET: Votar
        public async Task<IActionResult> Votar()
        {
            return View(_context.Candidato.ToList());
        }

        // GET: ElegirCandidato
        public async Task<IActionResult> ElegirCandidato(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candidato candidato = await _context.Candidato.Where(p => p.CandidatoId == id).FirstOrDefaultAsync();
            if (candidato == null)
            {
                return NotFound();
            }

            candidato.Votos = candidato.Votos + 1;
            _context.Update(candidato);
            await _context.SaveChangesAsync();

            return Redirect("Index");
        }

        // GET: Candidato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato
                .FirstOrDefaultAsync(m => m.CandidatoId == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // GET: Candidato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidatoId,Nombre,Partido,Votos")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidato);
        }

        // GET: Candidato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }
            return View(candidato);
        }

        // POST: Candidato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidatoId,Nombre,Partido,Votos")] Candidato candidato)
        {
            if (id != candidato.CandidatoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.CandidatoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(candidato);
        }

        // GET: Candidato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidato = await _context.Candidato
                .FirstOrDefaultAsync(m => m.CandidatoId == id);
            if (candidato == null)
            {
                return NotFound();
            }

            return View(candidato);
        }

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);
            if (candidato != null)
            {
                _context.Candidato.Remove(candidato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidato.Any(e => e.CandidatoId == id);
        }
    }
}
