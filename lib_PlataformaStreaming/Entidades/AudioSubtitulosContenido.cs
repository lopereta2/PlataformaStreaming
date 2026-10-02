using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class AudioSubtitulosContenido
    {
        [Key] public int IDConfig { get; set; }
        public string? TipoConfig { get; set; }
        [ForeignKey("PeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }

        [Column("Idiomas")] public int IdiomaId { get; set; }
        [ForeignKey(nameof(IdiomaId))] public Idiomas? _Idioma { get; set; }
    }
}
