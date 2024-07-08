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
    public class PostulacionesController : Controller
    {
        private readonly ProyectoDatabaseContext _context;

        public PostulacionesController(ProyectoDatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(int propuestaId)
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var postulacion = new Postulacion
            {
                UsuarioId = usuarioId,
                PropuestaId = propuestaId,
                FechaPostulacion = DateTime.Now
            };

            _context.Postulaciones.Add(postulacion);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Propuestas", new { id = propuestaId });
        }
    }
}
