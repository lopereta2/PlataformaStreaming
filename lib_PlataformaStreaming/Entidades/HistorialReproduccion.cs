using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class HistorialReproduccion
    {
        [Key] public int IDHistorial { get; set; }
        public int ProgresoSegundo { get; set; }
        public DateTime UltimaReproduccion { get; set; }
        public bool Completado { get; set; }
        [ForeignKey("Perfil")] public Perfiles? _Perfil { get; set; }
        [ForeignKey("PeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
        [ForeignKey("Episodio")] public Episodios? _Episodio { get; set; }
    }
}
