namespace PortafolioWebAdministracion.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PortafolioWebAdministracion.AppDbContext;
    using PortafolioWebAdministracion.DTOs;
    using PortafolioWebAdministracion.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public UsuariosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
     
        public async Task<IActionResult> Index()
        {
            var entidadesUsuario = await _context.Usuario.ToListAsync();
            var usuariosDto = _mapper.Map<List<UsuarioDTO>>(entidadesUsuario);
            return View(usuariosDto);
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntidad = await _context.Usuario.FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioEntidad == null)
            {
                return NotFound();
            }

            var usuarioDto = _mapper.Map<UsuarioDTO>(usuarioEntidad);
            return View(usuarioDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreUsuario,Contrasena")] UsuarioDTO usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var usuarioEntidad = _mapper.Map<Usuario>(usuarioDto);
                _context.Add(usuarioEntidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntidad = await _context.Usuario.FindAsync(id);
            if (usuarioEntidad == null)
            {
                return NotFound();
            }
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuarioEntidad);
            return View(usuarioDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreUsuario,Contrasena")] UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var usuarioEntidad = _mapper.Map<Usuario>(usuarioDto);
                try
                {
                    _context.Update(usuarioEntidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuarioEntidad.Id))
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
            return View(usuarioDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioEntidad = await _context.Usuario.FirstOrDefaultAsync(m => m.Id == id);
            var usuarioDto = _mapper.Map<UsuarioDTO>(usuarioEntidad);
            if (usuarioEntidad == null)
            {
                return NotFound();
            }         
            return View(usuarioDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
