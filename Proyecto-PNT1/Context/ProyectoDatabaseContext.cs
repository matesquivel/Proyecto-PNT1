using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_PNT1.Models;
using System.Collections.Generic;
namespace Proyecto_PNT1.Context
{
        public class ProyectoDatabaseContext : DbContext
        {
            public ProyectoDatabaseContext(DbContextOptions<ProyectoDatabaseContext>
           options) : base(options)
            {
            }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Propuesta> Propuestas { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
    }
    
}
