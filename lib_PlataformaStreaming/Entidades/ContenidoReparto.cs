using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class ContenidoReparto
    {
        [Key] public int IDReparto { get; set; }
        public string? RolPersona { get; set; }
        public string? NombrePersonaje { get; set; }
        [ForeignKey("PeliculaSerie")] public PeliculasSeries? _PeliculaSerie { get; set; }
        [ForeignKey("Persona")] public Personas? _Persona { get; set; }
    }
}
