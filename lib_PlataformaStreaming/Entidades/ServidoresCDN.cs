using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class ServidoresCDN
    {
        [Key] public int ID_CDN { get; set; }
        public string? Nombre { get; set; }
        public string? EspacioGeografico { get; set; }
        public string? Estado { get; set; }
    }
}
