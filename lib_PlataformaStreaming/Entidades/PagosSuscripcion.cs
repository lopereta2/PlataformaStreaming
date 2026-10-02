using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class PagosSuscripcion
    {
        [Key] public int IDPago { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string? EstadoPago { get; set; }
        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("PlanSuscripcion")] public PlanesSuscripcion? _PlanSuscripcion { get; set; }
    }
}
