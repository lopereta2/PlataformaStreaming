using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class ContenidoReparto
    {
        [Key]
        public int IDReparto { get; set; }
        public int IDPeliculaSerie { get; set; }
        public int IDPersona { get; set; }
        public string? RolPersona { get; set; }
        public string? NombrePersonaje { get; set; }

        [ForeignKey("IDPeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
        [ForeignKey("IDPersona")] public Personas? _Persona { get; set; }
    }
}
