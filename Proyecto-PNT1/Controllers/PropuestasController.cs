using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PNT1.Context;
using Proyecto_PNT1.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Proyecto_PNT1.Controllers
{
    public class PropuestasController : Controller
    {
        private readonly ProyectoDatabaseContext _context;

        public PropuestasController(ProyectoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Propuestas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propuestas.ToListAsync());
        }

        // GET: Propuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propuesta = await _context.Propuestas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propuesta == null)
            {
                return NotFound();
            }

            return View(propuesta);
        }

        // GET: Propuestas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propuestas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Requisitos,FechaPublicacion,Ubicacion,Remuneracion")] Propuesta propuesta)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                propuesta.CreadorId = userId;
                _context.Add(propuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propuesta);
        }

        // GET: Propuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propuesta = await _context.Propuestas.FindAsync(id);
            if (propuesta == null || propuesta.CreadorId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }
            return View(propuesta);
        }

        // POST: Propuestas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Requisitos,FechaPublicacion,Ubicacion,Remuneracion")] Propuesta propuesta)
        {
            if (id != propuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var originalPropuesta = await _context.Propuestas.FindAsync(id);
                    if (originalPropuesta == null || originalPropuesta.CreadorId != User.FindFirstValue(ClaimTypes.NameIdentifier))
                    {
                        return NotFound();
                    }

                    originalPropuesta.Titulo = propuesta.Titulo;
                    originalPropuesta.Descripcion = propuesta.Descripcion;
                    originalPropuesta.Requisitos = propuesta.Requisitos;
                    originalPropuesta.FechaPublicacion = propuesta.FechaPublicacion;
                    originalPropuesta.Ubicacion = propuesta.Ubicacion;
                    originalPropuesta.Remuneracion = propuesta.Remuneracion;

                    _context.Update(originalPropuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropuestaExists(propuesta.Id))
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
            return View(propuesta);
        }

        // GET: Propuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propuesta = await _context.Propuestas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propuesta == null || propuesta.CreadorId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            return View(propuesta);
        }

        // POST: Propuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propuesta = await _context.Propuestas.FindAsync(id);
            if (propuesta != null && propuesta.CreadorId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                _context.Propuestas.Remove(propuesta);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PropuestaExists(int id)
        {
            return _context.Propuestas.Any(e => e.Id == id);
        }

    }
}
