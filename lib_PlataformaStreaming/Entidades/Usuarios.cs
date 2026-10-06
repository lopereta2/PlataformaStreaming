using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class Usuarios
    {
        [Key]
        public int IDUsuario { get; set; }
        public int IDRol { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }

        [Column("ContraseñaHash")]
        public byte[] Contraseña { get; set; } = [];
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("IDRol")] public Roles? _Rol { get; set; }
        public List<PagosSuscripcion>? PagosSuscripcion { get; set; }
        public List<Perfiles>? Perfiles { get; set; }
        public List<DispositivosConectados>? DispositivosConectados { get; set; }
        public List<TicketsSoporte>? TicketsSoporte { get; set; }
    }
}