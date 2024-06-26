using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PNT1.Context;
using Proyecto_PNT1.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_PNT1.Controllers
{
    public class ProfesionalsController : Controller
    {
        private readonly ProyectoDatabaseContext _context;

        public ProfesionalsController(ProyectoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Profesionales
        public async Task<IActionResult> Index()
        {
            var profesionales = await _context.Usuarios.Where(u => u.EsProfesional).ToListAsync();
            return View(profesionales);
        }

        // GET: Profesionales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id && m.EsProfesional);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // Otros métodos (Create, Edit, Delete) pueden ser eliminados si no son necesarios
    }
}
