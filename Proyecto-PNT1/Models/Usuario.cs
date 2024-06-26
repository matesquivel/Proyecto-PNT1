using System.ComponentModel.DataAnnotations;

namespace Proyecto_PNT1.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "NOMBRE")]
        public string NombreUsuario { get; set; }

        [StringLength(25)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "APELLIDO")]
        public string ApellidoUsuario { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
        [Display(Name = "CORREO ELECTRÓNICO")]
        public string Email { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}