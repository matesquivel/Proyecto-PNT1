using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_PNT1.Models
{
    public class Usuario : IValidatableObject
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

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "¿Es Profesional?")]
        public bool EsProfesional { get; set; }

        [StringLength(50)]
        [Display(Name = "Profesión")]
        public string Profesion { get; set; }

        [StringLength(1000)]
        [Display(Name = "Experiencia")]
        public string Experiencia { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EsProfesional)
            {
                if (string.IsNullOrWhiteSpace(Profesion))
                {
                    yield return new ValidationResult("Debe especificar una profesión.", new[] { nameof(Profesion) });
                }

                if (string.IsNullOrWhiteSpace(Experiencia))
                {
                    yield return new ValidationResult("Debe especificar una experiencia.", new[] { nameof(Experiencia) });
                }
            }
        }
    }
}
