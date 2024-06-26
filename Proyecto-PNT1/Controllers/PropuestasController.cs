using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_PNT1.Context;
using Proyecto_PNT1.Models;

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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descripcion,Requisitos,Empresa,Ubicacion,Remuneracion")] Propuesta propuesta)
        {
            if (ModelState.IsValid)
            {
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
            if (propuesta == null)
            {
                return NotFound();
            }
            return View(propuesta);
        }

        // POST: Propuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descripcion,Requisitos,FechaPublicacion,Empresa")] Propuesta propuesta)
        {
            if (id != propuesta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propuesta);
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
            if (propuesta == null)
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
            if (propuesta != null)
            {
                _context.Propuestas.Remove(propuesta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropuestaExists(int id)
        {
            return _context.Propuestas.Any(e => e.Id == id);
        }
    }
}
