using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class HistorialReproduccion
    {
        [Key]
        public int IDHistorial { get; set; }
        public int IDPerfil { get; set; }
        public int IDPeliculaSerie { get; set; }
        public int IDEpisodio { get; set; }
        public int ProgresoSegundo { get; set; }
        public DateTime UltimaReproduccion { get; set; }
        public bool Completado { get; set; }

        [ForeignKey("IDPerfil")] public Perfiles? _Perfil { get; set; }
        [ForeignKey("IDPeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
        [ForeignKey("IDEpisodio")] public Episodios? _Episodio { get; set; }
    }
}
