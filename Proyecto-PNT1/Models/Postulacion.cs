using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_PNT1.Models
{
    public class Postulacion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public int PropuestaId { get; set; }
        public Propuesta Propuesta { get; set; }

        [Required]
        public DateTime FechaPostulacion { get; set; }
    }
}
