using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class ContenidoGeneros
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDContenidoGenero { get; set; }

        [Column("PeliculaSerie")]
        public int PeliculaSerieId { get; set; }

        [ForeignKey(nameof(PeliculaSerieId))]
        public PeliculasSeries? _PeliculaSerie { get; set; }

        [Column("Genero")]
        public int GeneroId { get; set; }

        [ForeignKey(nameof(GeneroId))]
        public Generos? _Genero { get; set; }

    }
}
