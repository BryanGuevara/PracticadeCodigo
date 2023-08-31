using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aburrimiento.Models;

namespace Aburrimiento.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly BaggdbContext _context;

        public JugadoresController(BaggdbContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index()
        {
              return _context.Jugadores != null ? 
                          View(await _context.Jugadores.ToListAsync()) :
                          Problem("Entity set 'BaggdbContext.Jugadores'  is null.");
        }

        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jugadores == null)
            {
                return NotFound();
            }

            var jugadore = await _context.Jugadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugadore == null)
            {
                return NotFound();
            }

            return View(jugadore);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Equipo,Activo")] Jugadore jugadore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jugadore);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jugadores == null)
            {
                return NotFound();
            }

            var jugadore = await _context.Jugadores.FindAsync(id);
            if (jugadore == null)
            {
                return NotFound();
            }
            return View(jugadore);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Equipo,Activo")] Jugadore jugadore)
        {
            if (id != jugadore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugadore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadoreExists(jugadore.Id))
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
            return View(jugadore);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jugadores == null)
            {
                return NotFound();
            }

            var jugadore = await _context.Jugadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugadore == null)
            {
                return NotFound();
            }

            return View(jugadore);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jugadores == null)
            {
                return Problem("Entity set 'BaggdbContext.Jugadores'  is null.");
            }
            var jugadore = await _context.Jugadores.FindAsync(id);
            if (jugadore != null)
            {
                _context.Jugadores.Remove(jugadore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadoreExists(int id)
        {
          return (_context.Jugadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
