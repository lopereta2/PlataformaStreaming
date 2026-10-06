using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_PlataformaStreaming.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }

        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<PlanesSuscripcion>? PlanesSuscripcion { get; set; }
        public DbSet<PagosSuscripcion>? PagosSuscripcion { get; set; }
        public DbSet<Perfiles>? Perfiles { get; set; }
        public DbSet<Generos>? Generos { get; set; }
        public DbSet<PeliculasSeries>? PeliculasSeries { get; set; }
        public DbSet<ContenidoGeneros>? ContenidoGeneros { get; set; }
        public DbSet<Temporadas>? Temporadas { get; set; }
        public DbSet<Episodios>? Episodios { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<ContenidoReparto>? ContenidoReparto { get; set; }
        public DbSet<Idiomas>? Idiomas { get; set; }
        public DbSet<AudioSubtitulosContenido>? AudioSubtitulosContenido { get; set; }
        public DbSet<ServidoresCDN>? ServidoresCDN { get; set; }
        public DbSet<HistorialReproduccion>? HistorialReproduccion { get; set; }
        public DbSet<MiLista>? MiLista { get; set; }
        public DbSet<CalificacionesResenias>? CalificacionesResenias { get; set; }
        public DbSet<DispositivosConectados>? DispositivosConectados { get; set; }
        public DbSet<TicketsSoporte>? TicketsSoporte { get; set; }
    }
}
