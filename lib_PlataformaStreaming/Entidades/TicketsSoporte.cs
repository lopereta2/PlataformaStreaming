using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class TicketsSoporte
    {
        [Key]
        public int IDTicket { get; set; }
        public int IDUsuario { get; set; }
        public string? Asunto { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("IDUsuario")] public Usuarios? _Usuario { get; set; }
    }
}
