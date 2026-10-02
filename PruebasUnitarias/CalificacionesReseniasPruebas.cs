using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias
{
    [TestClass]
    public class CalificacionesReseniasPruebas
    {
        private IConexion conexion;
        private CalificacionesResenias? entidad = null;

        public CalificacionesReseniasPruebas()
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

            var usuario = new Usuarios()
            {
                Nombre = "Felipe",
                Correo = "Felipe@gmail.com",
                Contraseña = Encoding.UTF8.GetBytes("123456ZSgHa"),
                FechaRegistro = new DateTime(2025, 12, 01),
                _Rol = rol
            };

            this.conexion.Usuarios!.Add(usuario);
            this.conexion.SaveChanges();

            var perfil = new Perfiles()
            {
                Nombre = "PerfilFelipe",
                AvatarURL = "https://avatar.com/2",
                EsInfantil = false,
                _Usuario = usuario
            };

            this.conexion.Perfiles!.Add(perfil);

            var contenido = new PeliculasSeries()
            {
                Titulo = "El juego del calamar",
                Descripcion = "Cientos de jugadores cortos de dinero aceptan una extraña invitación a competir en juegos infantiles." +
                " Adentro les espera un premio irresistible... con un riesgo mortal.",
                Tipo = "Serie",
                AnioLanzamiento = 2021,
                ClasificacionEdad = "16+"
            };

            this.conexion.PeliculasSeries!.Add(contenido);
            this.conexion.SaveChanges();


            this.entidad = new CalificacionesResenias()
            {
                Calificacion = 5,
                Comentario = "Esta bueno",
                Fecha = new DateTime(2026, 10, 01),
                _Perfil = perfil,
                _PeliculaSerie = contenido
            };

            this.conexion.CalificacionesResenias!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.CalificacionesResenias!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Calificacion = 4;
            this.entidad!.Comentario = "Actualización de la reseña";

            var entry = this.conexion!.Entry<CalificacionesResenias>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.CalificacionesResenias!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
