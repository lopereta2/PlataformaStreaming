using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class Perfiles
    {
        [Key]
        public int IDPerfil { get; set; }
        public int IDUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? AvatarURL { get; set; }
        public bool EsInfantil { get; set; }

        [ForeignKey("IDUsuario")] public Usuarios? _Usuario { get; set; }
    }
}
