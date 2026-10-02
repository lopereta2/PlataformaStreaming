using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Idiomas
    {
        [Key] public int IDIdioma { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoIso { get; set; }
        public List<AudioSubtitulosContenido>? AudioSubtitulosContenido { get; set; }
    }
}
