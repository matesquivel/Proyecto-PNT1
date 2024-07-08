using Microsoft.EntityFrameworkCore;
using Proyecto_PNT1.Models;

namespace Proyecto_PNT1.Context
{
    public class ProyectoDatabaseContext : DbContext
    {
        public ProyectoDatabaseContext(DbContextOptions<ProyectoDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
        public DbSet<Profesional> Profesionales { get; set; }
        public DbSet<Proyecto_PNT1.Models.Login> Login { get; set; } = default!;
        public DbSet<Postulacion> Postulaciones { get; set; }
        public DbSet<Contacto> Contactos { get; set; }

    }
}
