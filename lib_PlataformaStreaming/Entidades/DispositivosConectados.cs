using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class DispositivosConectados
    {
        [Key] public int IDDispositivo { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? TokenSesion { get; set; }
        public DateTime UltimoAcceso { get; set; }
        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
