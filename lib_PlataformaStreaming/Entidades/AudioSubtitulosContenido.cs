using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class AudioSubtitulosContenido
    {
        [Key] public int IDConfig { get; set; }
        public int IDPeliculaSerie { get; set; }
        public int IDIdioma { get; set; }
        public string? TipoConfig { get; set; }

        [ForeignKey("IDPeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
        [ForeignKey("IDIdioma")] public Idiomas? _Idioma { get; set; }
    }
}
