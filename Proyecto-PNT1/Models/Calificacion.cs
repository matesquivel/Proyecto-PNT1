using Proyecto_PNT1.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace Proyecto_PNT1;
public class Calificacion
{
    public int CalificacionId { get; set; }
    public int Puntaje { get; set; }
    public string Comentario { get; set; }

    public int UsuarioId { get; set; }
    public int PropuestaId { get; set; }

    [ForeignKey("UsuarioId")]
    public Usuario Usuario { get; set; }

    [ForeignKey("PropuestaId")]
    public Propuesta Propuesta { get; set; }
}
