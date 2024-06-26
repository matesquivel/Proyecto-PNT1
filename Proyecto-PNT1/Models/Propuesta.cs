namespace Proyecto_PNT1.Models
{
    public class Propuesta
    {
        public int PropuestaId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
