using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class PlanesSuscripcion
    {
        [Key] public int IDPlan { get; set; }
        public string? Nombre { get; set; }
        public decimal Precio { get; set; }
        public string? ResolucionMaxima { get; set; }
        public int PantallasSimultaneas { get; set; }
        public List<PagosSuscripcion>? PagosSuscripcion { get; set; }
    }
}
