using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_PNT1.Context;
using Proyecto_PNT1.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;

namespace Proyecto_PNT1.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ProyectoDatabaseContext _context;

        public UsuariosController(ProyectoDatabaseContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Perfil
        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email,Password,EsProfesional,Profesion,Experiencia")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                if (usuario.EsProfesional)
                {
                    var profesional = new Profesional
                    {
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido,
                        Email = usuario.Email,
                        Profesion = usuario.Profesion,
                        Experiencia = usuario.Experiencia
                    };
                    _context.Profesionales.Add(profesional);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email,Password,EsProfesional,Profesion,Experiencia")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();

                    if (usuario.EsProfesional)
                    {
                        var profesional = await _context.Profesionales
                            .FirstOrDefaultAsync(p => p.Email == usuario.Email);

                        if (profesional != null)
                        {
                            profesional.Nombre = usuario.Nombre;
                            profesional.Apellido = usuario.Apellido;
                            profesional.Profesion = usuario.Profesion;
                            profesional.Experiencia = usuario.Experiencia;

                            _context.Update(profesional);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            profesional = new Profesional
                            {
                                Nombre = usuario.Nombre,
                                Apellido = usuario.Apellido,
                                Email = usuario.Email,
                                Profesion = usuario.Profesion,
                                Experiencia = usuario.Experiencia
                            };
                            _context.Profesionales.Add(profesional);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                if (usuario.EsProfesional)
                {
                    var profesional = await _context.Profesionales
                        .FirstOrDefaultAsync(p => p.Email == usuario.Email);
                    if (profesional != null)
                    {
                        _context.Profesionales.Remove(profesional);
                    }
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Usuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Nombre),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }

        // GET: Usuarios/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Usuarios");
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
