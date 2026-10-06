using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class MiLista
    {
        [Key]
        public int IDLista { get; set; }
        public int IDPerfil { get; set; }
        public int IDPeliculaSerie { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("IDPerfil")] public Perfiles? _Perfil { get; set; }
        [ForeignKey("IDPeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
    }
}
