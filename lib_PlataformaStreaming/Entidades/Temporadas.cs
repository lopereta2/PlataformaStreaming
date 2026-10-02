using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Temporadas
    {
        [Key] public int IDTemporada { get; set; }
        public int Numero { get; set; }
        public string? Titulo { get; set; }
        [ForeignKey("PeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
        public List<Episodios>? Episodios { get; set; }
    }
}
