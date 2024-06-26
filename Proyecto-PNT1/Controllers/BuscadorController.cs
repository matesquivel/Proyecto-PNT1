using Microsoft.AspNetCore.Mvc;
using Proyecto_PNT1.Context;

namespace Proyecto_PNT1.Controllers
{
    public class BuscadorController : Controller
    {
        private readonly ProyectoDatabaseContext _context;

        public BuscadorController(ProyectoDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string keyword)
        {
            var resultados = _context.Propuestas
                .Where(p => p.Titulo.Contains(keyword) || p.Descripcion.Contains(keyword))
                .ToList();
            return View("Resultados", resultados);
        }
    }

}