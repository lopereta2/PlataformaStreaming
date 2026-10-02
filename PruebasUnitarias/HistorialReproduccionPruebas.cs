using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace PruebasUnitarias
{
    [TestClass]
    public class HistorialReproduccionPruebas
    {
        private IConexion conexion;
        private HistorialReproduccion? entidad = null;

        public HistorialReproduccionPruebas()
        {
            this.conexion = new Conexion();
            conexion.StringConexion = DatosGenerales.StringConexion();
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            var rol = this.conexion.Roles!
            .FirstOrDefault(r => r.Nombre == "Usuario");

            if (rol == null)
            {
                rol = new Roles()
                {
                    Nombre = "Usuario"
                };

                this.conexion.Roles!.Add(rol);
                this.conexion.SaveChanges();
            }

            var usuario = this.conexion.Usuarios!
                .FirstOrDefault(u => u.Correo == "Simon@gmail.com");

            if (usuario == null)
            {
                usuario = new Usuarios()
                {
                    Nombre = "Simon",
                    Correo = "Simon@gmail.com",
                    Contraseña = Encoding.UTF8.GetBytes("Simon2321H.HW2"),
                    FechaRegistro = new DateTime(2025, 12, 01),
                    RolId = rol.IDRol
                };

                this.conexion.Usuarios!.Add(usuario);
                this.conexion.SaveChanges();
            }

            // IMPORTANTE: este usuario ya existe en SQL Server
            this.conexion.Entry(usuario).State = EntityState.Unchanged;


            int usuarioId = usuario.IDUsuario;

            var perfil = this.conexion.Perfiles!
                .FirstOrDefault(p => p.Nombre == "PerfilSimon");

            if (perfil == null)
            {
                perfil = new Perfiles()
                {
                    Nombre = "PerfilSimon",
                    AvatarURL = "https://avatar.com/3",
                    EsInfantil = false,
                    UsuarioId = usuarioId
                };

                this.conexion.Perfiles!.Add(perfil);

                var contexto = (DbContext)this.conexion;

                foreach (var entry in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(
                        $"ANTES DEL SAVE - Entidad: {entry.Entity.GetType().Name} | Estado: {entry.State}");
                }

                this.conexion.SaveChanges();
            }

            var contenido = new PeliculasSeries()
            {
                Titulo = "Juego de tronos",
                Descripcion = "En un escenario que recuerda a la Europa Medieval, siete familias luchan por el control de Westeros" +
                " y usarán todos los medios a su alcance.",
                Tipo = "Serie",
                AnioLanzamiento = 2011,
                ClasificacionEdad = "16+"
            };

            this.conexion.PeliculasSeries!.Add(contenido);
            this.conexion.SaveChanges();

            var contexto = (DbContext)this.conexion;

            foreach (var entry in contexto.ChangeTracker.Entries())
            {
                Console.WriteLine(
                    $"Entidad: {entry.Entity.GetType().Name} | Estado: {entry.State}");
            }

            this.conexion.SaveChanges();

            var temporada = new Temporadas()
            {
                Numero = 8,
                Titulo = "Temporada 8",
                _PeliculaSerie = contenido
            };

            this.conexion.Temporadas!.Add(temporada);
            this.conexion.SaveChanges();

            var episodio = new Episodios()
            {
                Numero = 1,
                Titulo = "Winterfell",
                Duracion = 1,
                URLArchivoVideo = "PlataformaStreaming.com/co/LuzRojaLuzVerde/81040344",
                _Temporada = temporada
            };

            this.conexion.Episodios!.Add(episodio);
            this.conexion.SaveChanges();

            this.entidad = new HistorialReproduccion()
            {
                ProgresoSegundo = 27,
                UltimaReproduccion = new DateTime(2026, 10, 01),
                Completado = false,
                _Perfil = perfil,
                _Episodio = episodio
            };
            this.conexion.HistorialReproduccion!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.HistorialReproduccion!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.ProgresoSegundo = 50;
            this.entidad!.Completado = true;

            var entry = this.conexion!.Entry<HistorialReproduccion>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.HistorialReproduccion!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}