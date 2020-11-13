namespace PortafolioWebAdministracion.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PortafolioWebAdministracion.AppDbContext;
    using PortafolioWebAdministracion.DTOs;
    using PortafolioWebAdministracion.Models;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class BiograficosController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        private static byte[] _imagenSeleccionada;

        private static byte[] ImagenSeleccionada
        {
            get => _imagenSeleccionada;
            set
            {
                if (_imagenSeleccionada != value)
                    _imagenSeleccionada = value;
            }
        }

        public BiograficosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Biografico.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biografico = await _context.Biografico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biografico == null)
            {
                return NotFound();
            }

            return View(biografico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,Direccion,Telefono,Celular,Email,FechaNacimiento,Imagen,Perfil,EstadoCivil,Link")] BiograficoDTO biograficoDto)
        {
            if (ModelState.IsValid)
            {
                Biografico biografico = new Biografico
                {
                    Nombres = biograficoDto.Nombres,
                    Apellidos = biograficoDto.Apellidos,
                    FechaNacimiento = biograficoDto.FechaNacimiento,
                    Perfil = biograficoDto.Perfil,
                    Celular = biograficoDto.Celular,
                    Direccion = biograficoDto.Direccion,
                    Email = biograficoDto.Email,
                    EstadoCivil = biograficoDto.EstadoCivil,
                    Link = biograficoDto.Link,
                    Telefono = biograficoDto.Telefono
                };

                using (var memoryStream = new MemoryStream())
                {
                    await biograficoDto.Imagen.CopyToAsync(memoryStream);
                    biografico.Imagen = memoryStream.ToArray();
                }

                _context.Add(biografico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biograficoDto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biografico = await _context.Biografico.FindAsync(id);
            var biograficoDto = new BiograficoDTO
            {
                Nombres = biografico.Nombres,
                Apellidos = biografico.Apellidos,
                FechaNacimiento = biografico.FechaNacimiento,
                Perfil = biografico.Perfil,
                Celular = biografico.Celular,
                Direccion = biografico.Direccion,
                Email = biografico.Email,
                EstadoCivil = biografico.EstadoCivil,
                Telefono = biografico.Telefono,
                Link = biografico.Link
            };
            ImagenSeleccionada = biografico.Imagen;
            ViewBag.ImagenMostrar = ImagenSeleccionada;


            if (biografico == null)
            {
                return NotFound();
            }
            return View(biograficoDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,Direccion,Telefono,Celular,Email,FechaNacimiento,Imagen,Perfil,EstadoCivil,Link")] BiograficoDTO biograficoDto)
        {
            if (id != biograficoDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Biografico biografico = await _context.Biografico.FindAsync(id);
                biografico.Nombres = biograficoDto.Nombres;
                biografico.Apellidos = biograficoDto.Apellidos;
                biografico.FechaNacimiento = biograficoDto.FechaNacimiento;
                biografico.Perfil = biograficoDto.Perfil;
                biografico.Celular = biograficoDto.Celular;
                biografico.Direccion = biograficoDto.Direccion;
                biografico.Email = biograficoDto.Email;
                biografico.EstadoCivil = biograficoDto.EstadoCivil;
                biografico.Link = biograficoDto.Link;
                biografico.Telefono = biograficoDto.Telefono;

                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        if (biograficoDto.Imagen != null)
                        {
                            await biograficoDto.Imagen.CopyToAsync(memoryStream);
                            biografico.Imagen = memoryStream.ToArray();
                        }
                        else
                        {
                            biografico.Imagen = ImagenSeleccionada;
                        }
                    }

                    _context.Update(biografico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiograficoExists(biografico.Id))
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
            return View(biograficoDto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biografico = await _context.Biografico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biografico == null)
            {
                return NotFound();
            }

            return View(biografico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biografico = await _context.Biografico.FindAsync(id);
            _context.Biografico.Remove(biografico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiograficoExists(int id)
        {
            return _context.Biografico.Any(e => e.Id == id);
        }
    }
}
