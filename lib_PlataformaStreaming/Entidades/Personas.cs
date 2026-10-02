using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Personas
    {
        [Key] public int IDPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public List<ContenidoReparto>? ContenidoReparto { get; set; }
    }
}
