using lib_PlataformaStreaming.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_PlataformaStreaming.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Roles>? Roles { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<PlanesSuscripcion>? PlanesSuscripcion { get; set; }
        DbSet<PagosSuscripcion>? PagosSuscripcion { get; set; }
        DbSet<Perfiles>? Perfiles { get; set; }
        DbSet<Generos>? Generos { get; set; }
        DbSet<PeliculasSeries>? PeliculasSeries { get; set; }
        DbSet<ContenidoGeneros>? ContenidoGeneros { get; set; }
        DbSet<Temporadas>? Temporadas { get; set; }
        DbSet<Episodios>? Episodios { get; set; }
        DbSet<Personas>? Personas { get; set; }
        DbSet<ContenidoReparto>? ContenidoReparto { get; set; }
        DbSet<Idiomas>? Idiomas { get; set; }
        DbSet<AudioSubtitulosContenido>? AudioSubtitulosContenido { get; set; }
        DbSet<ServidoresCDN>? ServidoresCDN { get; set; }
        DbSet<HistorialReproduccion>? HistorialReproduccion { get; set; }
        DbSet<MiLista>? MiLista { get; set; }
        DbSet<CalificacionesResenias>? CalificacionesResenias { get; set; }
        DbSet<DispositivosConectados>? DispositivosConectados { get; set; }
        DbSet<TicketsSoporte>? TicketsSoporte { get; set; }

        void Attach(Usuarios usuario);
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}