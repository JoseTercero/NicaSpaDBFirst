using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NicaSpaDBFirst.Models;

namespace NicaSpaDBFirst.Controllers
{
    public class TipousuariosController : Controller
    {
        private readonly SpaContext _context;

        public TipousuariosController(SpaContext context)
        {
            _context = context;
        }

        // GET: Tipousuarios
        public async Task<IActionResult> Index()
        {
              return _context.Tipousuarios != null ? 
                          View(await _context.Tipousuarios.ToListAsync()) :
                          Problem("Entity set 'SpaContext.Tipousuarios'  is null.");
        }

        // GET: Tipousuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipousuarios == null)
            {
                return NotFound();
            }

            var tipousuario = await _context.Tipousuarios
                .FirstOrDefaultAsync(m => m.Codigotipousuario == id);
            if (tipousuario == null)
            {
                return NotFound();
            }

            return View(tipousuario);
        }

        // GET: Tipousuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipousuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigotipousuario,Tipousuario1")] Tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipousuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipousuario);
        }

        // GET: Tipousuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipousuarios == null)
            {
                return NotFound();
            }

            var tipousuario = await _context.Tipousuarios.FindAsync(id);
            if (tipousuario == null)
            {
                return NotFound();
            }
            return View(tipousuario);
        }

        // POST: Tipousuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigotipousuario,Tipousuario1")] Tipousuario tipousuario)
        {
            if (id != tipousuario.Codigotipousuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipousuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipousuarioExists(tipousuario.Codigotipousuario))
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
            return View(tipousuario);
        }

        // GET: Tipousuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipousuarios == null)
            {
                return NotFound();
            }

            var tipousuario = await _context.Tipousuarios
                .FirstOrDefaultAsync(m => m.Codigotipousuario == id);
            if (tipousuario == null)
            {
                return NotFound();
            }

            return View(tipousuario);
        }

        // POST: Tipousuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipousuarios == null)
            {
                return Problem("Entity set 'SpaContext.Tipousuarios'  is null.");
            }
            var tipousuario = await _context.Tipousuarios.FindAsync(id);
            if (tipousuario != null)
            {
                _context.Tipousuarios.Remove(tipousuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipousuarioExists(int id)
        {
          return (_context.Tipousuarios?.Any(e => e.Codigotipousuario == id)).GetValueOrDefault();
        }
    }
}
