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
    public class ContactosController : Controller
    {
        private readonly ProyectoDatabaseContext _context;

        public ContactosController(ProyectoDatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(int profesionalId)
        {
            var empresaId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contacto = new Contacto
            {
                EmpresaId = empresaId,
                ProfesionalId = profesionalId,
                FechaContacto = DateTime.Now
            };

            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Usuarios", new { id = profesionalId });
        }
    }
}
