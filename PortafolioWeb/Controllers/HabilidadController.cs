using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortafolioWebAdministracion.AppDbContext;
using PortafolioWebAdministracion.Models;

namespace PortafolioWebAdministracion.Controllers
{
    public class HabilidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabilidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Habilidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habilidad.ToListAsync());
        }

        // GET: Habilidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidad = await _context.Habilidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return View(habilidad);
        }

        // GET: Habilidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habilidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HabilidadDescripcion,Nivel")] Habilidad habilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habilidad);
        }

        // GET: Habilidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidad = await _context.Habilidad.FindAsync(id);
            if (habilidad == null)
            {
                return NotFound();
            }
            return View(habilidad);
        }

        // POST: Habilidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HabilidadDescripcion,Nivel")] Habilidad habilidad)
        {
            if (id != habilidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilidadExists(habilidad.Id))
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
            return View(habilidad);
        }

        // GET: Habilidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidad = await _context.Habilidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidad == null)
            {
                return NotFound();
            }

            return View(habilidad);
        }

        // POST: Habilidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habilidad = await _context.Habilidad.FindAsync(id);
            _context.Habilidad.Remove(habilidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilidadExists(int id)
        {
            return _context.Habilidad.Any(e => e.Id == id);
        }
    }
}
