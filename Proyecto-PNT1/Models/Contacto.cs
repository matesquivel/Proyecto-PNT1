using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_PNT1.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmpresaId { get; set; }
        public Usuario Empresa { get; set; }

        [Required]
        public int ProfesionalId { get; set; }
        public Usuario Profesional { get; set; }

        [Required]
        public DateTime FechaContacto { get; set; }
    }
}
