using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_PlataformaStreaming.Entidades
{
    public class PagosSuscripcion
    {
        [Key]
        public int IDPago { get; set; }
        public int IDUsuario { get; set; }
        public int IDPlanSuscripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string? EstadoPago { get; set; }

        [ForeignKey("IDUsuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("IDPlanSuscripcion")] public PlanesSuscripcion? _PlanSuscripcion { get; set; }
    }
}
