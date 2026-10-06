using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = DatosGenerales.StringConexion();
    
    var lista_roles = conexion.Roles!.ToList();

    var lista_usuarios = conexion.Usuarios!.
        Include(x => x._Rol)
        .ToList();

    var lista_planes_suscripcion = conexion.PlanesSuscripcion!.ToList();

    var lista_pagos_suscripcion = conexion.PagosSuscripcion!
        .Include(x => x._Usuario)
        .Include(x => x._PlanSuscripcion)
        .ToList();

    var lista_perfiles = conexion.Perfiles!
        .Include(x => x._Usuario)
        .ToList();

    var lista_generos = conexion.Generos!.ToList();

    var lista_peliculas_series = conexion.PeliculasSeries!.ToList();

    var lista_contenidos_generos = conexion.ContenidoGeneros!
        .Include(x => x._Genero)
        .Include(x => x._PeliculaSerie)
        .ToList();

    var lista_temporadas = conexion.Temporadas!
        .Include(x => x._PeliculaSerie)
        .ToList();

    var lista_episodios = conexion.Episodios!
        .Include(x => x._Temporada)
        .ToList();

    var lista_personas = conexion.Personas!.ToList();

    var lista_contenidos_reparto = conexion.ContenidoReparto!
        .Include(x => x._PeliculaSerie)
        .Include(x => x._Persona)
        .ToList();

    var lista_idiomas = conexion.Idiomas!.ToList();

    var lista_audio_subtitulos_contenidos = conexion.AudioSubtitulosContenido!
        .Include(x => x._PeliculaSerie)
        .Include(x => x._Idioma)
        .ToList();

    var lista_servidores_cdn = conexion.ServidoresCDN!.ToList();

    var lista_historial_reproduccion = conexion.HistorialReproduccion!
        .Include(x => x._Perfil)
        .Include(x => x._PeliculaSerie)
        .Include(x => x._Episodio)
        .ToList();

    var mi_lista = conexion.MiLista!
        .Include(x => x._Perfil)
        .Include(x => x._PeliculaSerie)
        .ToList();

    var lista_calificaciones_resenias = conexion.CalificacionesResenias!
        .Include(x => x._Perfil)
        .Include(x => x._PeliculaSerie)
        .ToList();

    var lista_dispositivos_conectados = conexion.DispositivosConectados!
        .Include(x => x._Usuario)
        .ToList();

    var lista_tickets_soporte = conexion.TicketsSoporte!
        .Include(x => x._Usuario)
        .ToList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("presentacion_consola");