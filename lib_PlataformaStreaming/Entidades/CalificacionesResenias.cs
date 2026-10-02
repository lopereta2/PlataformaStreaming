using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class CalificacionesResenias
    {
        [Key] public int IDResenia { get; set; }
        public int Calificacion { get; set; }
        public string? Comentario { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("Perfil")] public Perfiles? _Perfil { get; set; }
        [ForeignKey("PeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
    }
}
