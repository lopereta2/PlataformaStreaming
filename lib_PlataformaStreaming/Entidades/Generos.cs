using System.ComponentModel.DataAnnotations;

namespace lib_PlataformaStreaming.Entidades
{
    public class Generos
    {
        [Key]
        public int IDGenero { get; set; }
        public string? Nombre { get; set; }

        public List<ContenidoGeneros>? ContenidoGeneros { get; set; }
    }
}
