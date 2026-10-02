using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Roles
    {
        [Key] public int IDRol { get; set; }
        public string? Nombre { get; set; }
        public List<Usuarios>? Usuarios { get; set; }
    }
}
