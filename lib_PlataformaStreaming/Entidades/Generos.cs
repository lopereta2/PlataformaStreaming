using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Generos
    {
        [Key] public int IDGenero { get; set; }
        public string? Nombre { get; set; }
        public List<ContenidoGeneros>? ContenidoGeneros { get; set; }
    }
}
