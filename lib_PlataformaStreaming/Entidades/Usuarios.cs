using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Usuarios
    {
        [Key] public int IDUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }

        [Column("ContraseñaHash")] public byte[] Contraseña { get; set; } = [];
        public DateTime FechaRegistro { get; set; }
        [Column("Rol")] public int RolId { get; set; }
        [ForeignKey(nameof(RolId))] public Roles? _Rol { get; set; }
        public List<PagosSuscripcion>? PagosSuscripcion { get; set; }
        public List<Perfiles>? Perfiles { get; set; }
        public List<DispositivosConectados>? DispositivosConectados { get; set; }
        public List<TicketsSoporte>? TicketsSoporte { get; set; }
    }
}
