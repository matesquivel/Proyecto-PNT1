using System.ComponentModel.DataAnnotations;

namespace Proyecto_PNT1.Models
{
    public class Profesional
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Profesión")]
        public string Profesion { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Experiencia")]
        public string Experiencia { get; set; }
    }
}
