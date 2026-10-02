using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class PeliculasSeries
    {
        [Key] public int IDContenido { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
        public int AnioLanzamiento { get; set; }
        public string? ClasificacionEdad { get; set; }
        public List<ContenidoGeneros>? ContenidoGeneros { get; set; }
        public List<Temporadas>? Temporadas { get; set; }
        public List<ContenidoReparto>? ContenidoReparto { get; set; }
        public List<AudioSubtitulosContenido>? AudioSubtitulosContenido { get; set; }
        public List<HistorialReproduccion>? HistorialReproduccion { get; set; }
        public List<MiLista>? MiLista { get; set; }
        public List<CalificacionesResenias>? CalificacionesResenias { get; set; }
    }
}
