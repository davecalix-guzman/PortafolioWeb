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
    public class ExperienciaLaboralController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperienciaLaboralController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExperienciaLaboral
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExperienciaLaboral.OrderByDescending(x => x.FechaFinalizacion).ToListAsync());
        }

        // GET: ExperienciaLaboral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaboral
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaboral/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExperienciaLaboral/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreEmpresa,Puesto,Responsabilidad,FechaInicio,FechaFinalizacion")] ExperienciaLaboral experienciaLaboral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienciaLaboral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaboral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaboral.FindAsync(id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }
            return View(experienciaLaboral);
        }

        // POST: ExperienciaLaboral/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreEmpresa,Puesto,Responsabilidad,FechaInicio,FechaFinalizacion")] ExperienciaLaboral experienciaLaboral)
        {
            if (id != experienciaLaboral.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienciaLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienciaLaboralExists(experienciaLaboral.Id))
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
            return View(experienciaLaboral);
        }

        // GET: ExperienciaLaboral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienciaLaboral = await _context.ExperienciaLaboral
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experienciaLaboral == null)
            {
                return NotFound();
            }

            return View(experienciaLaboral);
        }

        // POST: ExperienciaLaboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experienciaLaboral = await _context.ExperienciaLaboral.FindAsync(id);
            _context.ExperienciaLaboral.Remove(experienciaLaboral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienciaLaboralExists(int id)
        {
            return _context.ExperienciaLaboral.Any(e => e.Id == id);
        }
    }
}
