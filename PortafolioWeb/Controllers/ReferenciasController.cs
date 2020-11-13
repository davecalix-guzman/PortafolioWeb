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
    public class ReferenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Referencias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Referencias.ToListAsync());
        }

        // GET: Referencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referencia = await _context.Referencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referencia == null)
            {
                return NotFound();
            }

            return View(referencia);
        }

        // GET: Referencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Referencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompleto,Profesion,Telefono,Email,Link")] Referencia referencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(referencia);
        }

        // GET: Referencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referencia = await _context.Referencias.FindAsync(id);
            if (referencia == null)
            {
                return NotFound();
            }
            return View(referencia);
        }

        // POST: Referencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompleto,Profesion,Telefono,Email,Link")] Referencia referencia)
        {
            if (id != referencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenciaExists(referencia.Id))
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
            return View(referencia);
        }

        // GET: Referencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referencia = await _context.Referencias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referencia == null)
            {
                return NotFound();
            }

            return View(referencia);
        }

        // POST: Referencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referencia = await _context.Referencias.FindAsync(id);
            _context.Referencias.Remove(referencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenciaExists(int id)
        {
            return _context.Referencias.Any(e => e.Id == id);
        }
    }
}
