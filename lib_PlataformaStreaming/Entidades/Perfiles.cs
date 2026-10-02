using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_PlataformaStreaming.Entidades
{
    public class Perfiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPerfil { get; set; }

        public string? Nombre { get; set; }
        public string? AvatarURL { get; set; }
        public bool EsInfantil { get; set; }

        [Column("Usuarios")]
        public int UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public Usuarios? _Usuario { get; set; }
    }
}
