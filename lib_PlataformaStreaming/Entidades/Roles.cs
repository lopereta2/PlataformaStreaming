using System.ComponentModel.DataAnnotations;

namespace lib_PlataformaStreaming.Entidades
{
    public class Roles
    {
        [Key]
        public int IDRol { get; set; }
        public string? Nombre { get; set; }
        public List<Usuarios>? Usuarios { get; set; }
    }
}
