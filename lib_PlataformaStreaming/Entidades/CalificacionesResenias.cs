using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class CalificacionesResenias
    {
        [Key]
        public int IDResenia { get; set; }
        public int IDPerfil { get; set; }
        public int IDPeliculaSerie { get; set; }
        public int Calificacion { get; set; }
        public string? Comentario { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("IDPerfil")] public Perfiles? _Perfil { get; set; }
        [ForeignKey("IDPeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
    }
}
