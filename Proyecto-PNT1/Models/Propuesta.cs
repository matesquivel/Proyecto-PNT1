using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_PNT1.Models

{
    public class Propuesta
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Requisitos")]
        public string Requisitos { get; set; }

        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Fecha de Publicación")]
        public DateTime FechaPublicacion { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Ubicación")]
        public string Ubicacion { get; set; }

        [Required(ErrorMessage = "Debe especificar un valor para {0}.")]
        [Display(Name = "Remuneración")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Remuneracion { get; set; }

        [Required]
        public string CreadorId { get; set; }
    }
}
