using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class ContenidoGeneros
    {
        [Key]
        public int IDContenidoGenero { get; set; }
        public int IDPeliculaSerie { get; set; }
        public int IDGenero { get; set; }

        [ForeignKey("IDPeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
        [ForeignKey("IDGenero")] public Generos? _Genero { get; set; }

    }
}
