using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PNT1.Context;
using Proyecto_PNT1.Models;

namespace Proyecto_PNT1.Controllers
{
    public class UsuarioController : Controller
    {
            private readonly ProyectoDatabaseContext _context;

            public UsuarioController(ProyectoDatabaseContext context)
            {
                _context = context;
            }

            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(Usuario usuario)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                return View(usuario);
            }

            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(string email, string password)
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
                if (usuario != null)
                {
                    // Manejar inicio de sesión exitoso (establecer cookie/sesión)
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Correo electrónico o contraseña incorrectos.");
                return View();
            }
        

    }
}
