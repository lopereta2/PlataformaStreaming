using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Episodios
    {
        [Key] public int IDEpisodio { get; set; }
        public int Numero { get; set; }
        public string? Titulo { get; set; }
        public int Duracion { get; set; }
        public string? URLArchivoVideo { get; set; }
        [ForeignKey("Temporada")] public Temporadas? _Temporada { get; set; }
        public List<HistorialReproduccion>? HistorialReproduccion { get; set; }
    }
}
