namespace MVCConnectWork.Models
{
    public class Postulacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Propuesta Propuesta { get; set; }
        public int PropuestaId { get; set; }
        public Archivo CV { get; set; }
    }
}
