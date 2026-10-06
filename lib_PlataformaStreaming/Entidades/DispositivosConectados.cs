using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class DispositivosConectados
    {
        [Key] 
        public int IDDispositivo { get; set; }
        public int IDUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? TokenSesion { get; set; }
        public DateTime UltimoAcceso { get; set; }

        [ForeignKey("IDUsuario")] public Usuarios? _Usuario { get; set; }
    }
}
